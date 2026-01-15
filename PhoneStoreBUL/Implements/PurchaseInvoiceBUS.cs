using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneStoreBUL.Interfaces;
using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class PurchaseInvoiceBUS : IPurchaseInvoiceBUS
    {
        private readonly IPurchaseInvoiceDAO invoiceDao;

        public PurchaseInvoiceBUS(IPurchaseInvoiceDAO invoiceDao)
        {
            this.invoiceDao = invoiceDao;
        }

        public Task<List<PurchaseInvoice>> GetAll() => invoiceDao.GetAll();

        public Task<PurchaseInvoice?> GetById(int id) => invoiceDao.GetById(id);

        public Task<PurchaseInvoice?> GetByCode(string code) => invoiceDao.GetByCode(code);

        public Task<bool> Add(PurchaseInvoice entity) => invoiceDao.Add(entity);

        public Task<bool> Update(PurchaseInvoice entity) => invoiceDao.Update(entity);

        public Task<bool> Delete(int id) => invoiceDao.Delete(id);

        // ===== Transaction nghiệp vụ =====
        public async Task<bool> CreatePurchaseInvoiceWithDetails(PurchaseInvoice invoice, List<PurchaseInvoiceDetail> details)
        {
            if (invoice == null) return false;
            if (details == null || details.Count == 0) return false;
            if (details.Any(d => d.Quantity <= 0 || d.UnitCost < 0)) return false;

            using var db = new PhoneStoreDBContext();
            using var tx = await db.Database.BeginTransactionAsync();

            try
            {
                invoice.TotalCost = details.Sum(d => d.UnitCost * d.Quantity);

                // 1) add invoice
                db.PurchaseInvoices.Add(invoice);
                await db.SaveChangesAsync();

                // 2) add details
                foreach (var d in details)
                {
                    d.PurchaseInvoiceId = invoice.PurchaseInvoiceId;
                }
                db.PurchaseInvoiceDetails.AddRange(details);

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
