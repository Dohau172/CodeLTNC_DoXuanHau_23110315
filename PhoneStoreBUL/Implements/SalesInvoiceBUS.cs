using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneStoreBUL.Interfaces;
using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;
using static PhoneStoreDAL.Entities.Enums;

namespace PhoneStoreBUL.Implements
{
    public class SalesInvoiceBUS : ISalesInvoiceBUS
    {
        private readonly ISalesInvoiceDAO invoiceDao;

        public SalesInvoiceBUS(ISalesInvoiceDAO invoiceDao)
        {
            this.invoiceDao = invoiceDao;
        }

        public Task<List<SalesInvoice>> GetAll() => invoiceDao.GetAll();

        public Task<SalesInvoice?> GetById(int id) => invoiceDao.GetById(id);

        public Task<SalesInvoice?> GetByCode(string code) => invoiceDao.GetByCode(code);

        public Task<bool> Add(SalesInvoice entity) => invoiceDao.Add(entity);

        public Task<bool> Update(SalesInvoice entity) => invoiceDao.Update(entity);

        public Task<bool> Delete(int id) => invoiceDao.Delete(id);

        // ===== Transaction nghiệp vụ =====
        public async Task<bool> CreateSalesInvoiceWithImeis(SalesInvoice invoice, List<string> imeis)
        {
            if (invoice == null) return false;
            if (imeis == null || imeis.Count == 0) return false;

            imeis = imeis
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .Distinct()
                .ToList();

            if (imeis.Count == 0) return false;

            using var db = new PhoneStoreDBContext();
            using var tx = await db.Database.BeginTransactionAsync();

            try
            {
                // Load IMEI + ProductVariant để lấy giá
                var units = await db.ImeiUnits
                    .Include(x => x.ProductVariant)
                    .Where(x => imeis.Contains(x.Imei))
                    .ToListAsync();

                if (units.Count != imeis.Count) return false;

                // Check trạng thái kho
                if (units.Any(u => u.Status != ImeiStatus.InStock))
                    return false;

                // Tính tiền (sale price theo variant)
                var subTotal = units.Sum(u => u.ProductVariant?.SalePrice ?? 0m);

                invoice.SubTotal = subTotal;
                invoice.Discount = invoice.Discount < 0 ? 0 : invoice.Discount;
                invoice.Tax = invoice.Tax < 0 ? 0 : invoice.Tax;
                invoice.TotalAmount = invoice.SubTotal - invoice.Discount + invoice.Tax;

                // 1) Add invoice
                db.SalesInvoices.Add(invoice);
                await db.SaveChangesAsync();

                // 2) Add details
                var details = units.Select(u => new SalesInvoiceDetail
                {
                    SalesInvoiceId = invoice.SalesInvoiceId,
                    Imei = u.Imei,
                    SalePrice = u.ProductVariant?.SalePrice ?? 0m
                }).ToList();

                db.SalesInvoiceDetails.AddRange(details);

                // 3) Update IMEI status
                foreach (var u in units)
                {
                    u.Status = ImeiStatus.Sold;
                    u.SoldAt = invoice.SoldAt;
                    u.WarrantyStartDate = invoice.SoldAt;
                }

                await db.SaveChangesAsync();
                await tx.CommitAsync();
                return true;
            }
            catch
            {
                await tx.RollbackAsync();
                return false;
            }
        }
    }
}
