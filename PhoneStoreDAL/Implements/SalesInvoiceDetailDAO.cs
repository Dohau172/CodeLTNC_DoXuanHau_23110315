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
    public class SalesInvoiceDetailDAO: ISalesInvoiceDetailDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        public async Task<List<SalesInvoiceDetail>> GetAll()
        {
            return await context.SalesInvoiceDetails.ToListAsync();
        }
        public async Task<List<SalesInvoiceDetail>> GetBySalesInvoiceId(int salesInvoiceId)
        {
            return await context.SalesInvoiceDetails
                .Where(x => x.SalesInvoiceId == salesInvoiceId)
                .ToListAsync();
        }
        public async Task<SalesInvoiceDetail?> GetById(int id)
        {
            return await context.SalesInvoiceDetails.FirstOrDefaultAsync(x=>x.SalesInvoiceDetailId == id);
        }

        public async Task<bool> Add(SalesInvoiceDetail entity)
        {
            try
            {
                await context.SalesInvoiceDetails.AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Update(SalesInvoiceDetail entity)
        {
            try
            {
                if (entity == null || entity.SalesInvoiceDetailId <= 0) return false;
                context.SalesInvoiceDetails.Update(entity);
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
                var entity = await context.SalesInvoiceDetails.FirstOrDefaultAsync(x => x.SalesInvoiceDetailId == id);
                if (entity == null) return false;
                context.SalesInvoiceDetails.Remove(entity);
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
