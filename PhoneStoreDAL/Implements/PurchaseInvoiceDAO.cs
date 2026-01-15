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
    public class PurchaseInvoiceDAO:IPurchaseInvoiceDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        public async Task<List<PurchaseInvoice>> GetAll()
        {
            return await context.PurchaseInvoices.ToListAsync();
        }
        public async Task<PurchaseInvoice?> GetById(int id)
        {
            return await context.PurchaseInvoices.FirstOrDefaultAsync(x=>x.PurchaseInvoiceId == id);
        }
        public async Task<PurchaseInvoice?> GetByCode(string code)
        {
            return await context.PurchaseInvoices.FirstOrDefaultAsync(x=>x.Code == code);
        }

        public async Task<bool> Add(PurchaseInvoice entity)
        {
            try
            {
                await context.PurchaseInvoices.AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Update(PurchaseInvoice entity)
        {
            try
            {
                if (entity == null || entity.PurchaseInvoiceId <= 0) return false;
                context.PurchaseInvoices.Update(entity);
                await context.SaveChangesAsync();
                return true;
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
                var entity = await context.PurchaseInvoices.FirstOrDefaultAsync(x => x.PurchaseInvoiceId == id);
                if (entity == null) return false;
                context.PurchaseInvoices.Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
