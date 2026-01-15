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
    public class WarrantyStatusLogDAO:IWarrantyStatusLogDAO
    {
        PhoneStoreDBContext context= new PhoneStoreDBContext();
        public async Task<List<WarrantyStatusLog>> GetAll()
        {
            return await context.WarrantyStatusLogs.ToListAsync();
        }
        public async Task<List<WarrantyStatusLog>> GetByTicketId(int warrantyTicketId)
        {
            return await context.WarrantyStatusLogs
                .Where(x => x.WarrantyTicketId == warrantyTicketId)
                .ToListAsync();
        }
        public async Task<WarrantyStatusLog?> GetById(int id)
        {
            return await context.WarrantyStatusLogs
                .FirstOrDefaultAsync(x => x.WarrantyStatusLogId == id);
        }

        public async Task<bool> Add(WarrantyStatusLog entity)
        {
            try
            {
                await context.WarrantyStatusLogs.AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Update(WarrantyStatusLog entity)
        {
            try
            {
                if (entity == null || entity.WarrantyStatusLogId <= 0) return false;

                context.WarrantyStatusLogs.Update(entity);
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
                var e = await context.WarrantyStatusLogs.FindAsync(id);
                if (e == null) return false;
                context.WarrantyStatusLogs.Remove(e);
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
