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
    public class SalesInvoiceDAO:ISalesInvoiceDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        public async Task<List<SalesInvoice>> GetAll()
        {
            return await context.SalesInvoices
                .Include(si => si.Customer)
                .Include(si => si.Employee)
                .Include(si => si.Details)
                .ToListAsync();
        }
        public async Task<SalesInvoice?> GetById(int id)
        {
            return await context.SalesInvoices
                .Include(si => si.Customer)
                .Include(si => si.Employee)
                .Include(si => si.Details)
                .FirstOrDefaultAsync(si => si.SalesInvoiceId == id);
        }
        public async Task<SalesInvoice?> GetByCode(string code)
        {
            return await context.SalesInvoices
                .Include(si => si.Customer)
                .Include(si => si.Employee)
                .Include(si => si.Details)
                .FirstOrDefaultAsync(si => si.Code == code);
        }

        public async Task<bool> Add(SalesInvoice entity)
        {
            try
            {
                await context.SalesInvoices.AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(SalesInvoice entity)
        {
            try
            {
                if (entity == null || entity.SalesInvoiceId <= 0) return false;

                context.SalesInvoices.Update(entity);
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
                var e = await context.SalesInvoices.FindAsync(id);
                if (e == null) return false;
                context.SalesInvoices.Remove(e);
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
