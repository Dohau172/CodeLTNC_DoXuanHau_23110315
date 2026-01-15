using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;

namespace PhoneStoreDAL.Implements
{
    public class PurchaseInvoiceDetailDAO:IPurchaseInvoiceDetailDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        public async Task<List<PurchaseInvoiceDetail>> GetAll()
        {
            return await context.PurchaseInvoiceDetails.Include("PurchaseInvoice")
                .Include(d => d.ProductVariant)
                .OrderByDescending(x => x.PurchaseInvoiceDetailId)
                .ToListAsync();

        }
        public async Task<List<PurchaseInvoiceDetail>> GetByPurchaseInvoiceId(int purchaseInvoiceId)
        {
            return await context.PurchaseInvoiceDetails
                .Include(d => d.ProductVariant)
                .Where(x => x.PurchaseInvoiceId == purchaseInvoiceId)
                .OrderBy(x => x.PurchaseInvoiceDetailId)
                .ToListAsync();

        }
        public async Task<PurchaseInvoiceDetail?> GetById(int id)
        {
            return await context.PurchaseInvoiceDetails
               .Include("PurchaseInvoice")
               .Include(d => d.ProductVariant)
               .FirstOrDefaultAsync(x => x.PurchaseInvoiceDetailId == id);

        }

        public async Task<bool> Add(PurchaseInvoiceDetail entity)
        {
            try
            {
                if (entity == null) return false;

                await context.PurchaseInvoiceDetails.AddAsync(entity);
                return await context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(PurchaseInvoiceDetail entity)
        {
            try
            {
                if (entity == null || entity.PurchaseInvoiceDetailId <= 0) return false;

                context.PurchaseInvoiceDetails.Update(entity);
                return await context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                if (id <= 0) return false;

                var detail = await context.PurchaseInvoiceDetails
                    .FirstOrDefaultAsync(x => x.PurchaseInvoiceDetailId == id);

                if (detail == null) return false;

                context.PurchaseInvoiceDetails.Remove(detail);
                return await context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
