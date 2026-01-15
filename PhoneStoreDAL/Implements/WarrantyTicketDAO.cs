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
    public class WarrantyTicketDAO:IWarrantyTicketDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        public async Task<List<WarrantyTicket>> GetAll()
        {
            return await context.WarrantyTickets
                .Include(wt => wt.ImeiUnit)
                .Include(wt => wt.TechnicianEmployee)
                .Include(wt => wt.StatusLogs)
                .ToListAsync();
        }
        public async Task<WarrantyTicket?> GetById(int id)
        {
            return await context.WarrantyTickets
                .Include(wt => wt.ImeiUnit)
                .Include(wt => wt.TechnicianEmployee)
                .Include(wt => wt.StatusLogs)
                .FirstOrDefaultAsync(x => x.WarrantyTicketId == id);
        }
        public async Task<List<WarrantyTicket>> GetByImei(string imei)
        {
            imei = (imei ?? "").Trim();
            if (imei.Length == 0) return null;

            return await context.WarrantyTickets
                .Include(wt => wt.ImeiUnit)
                .Include(wt => wt.TechnicianEmployee)
                .Include(wt => wt.StatusLogs)
                .Where(x => x.Imei == imei)
                .ToListAsync();

        }
        public async Task<WarrantyTicket?> GetByCode(string code)
        {
            code = (code ?? "").Trim();
            if (code.Length == 0) return null;

            return await context.WarrantyTickets
                .Include(wt => wt.ImeiUnit)
                .Include(wt => wt.TechnicianEmployee)
                .Include(wt => wt.StatusLogs)
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<bool> Add(WarrantyTicket entity)
        {
            try
            {
                await context.WarrantyTickets.AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(WarrantyTicket entity)
        {
            try
            {
                context.WarrantyTickets.Update(entity);
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
                var e = await context.WarrantyTickets.FirstOrDefaultAsync(x => x.WarrantyTicketId == id);
                if (e == null) return false;

                context.WarrantyTickets.Remove(e);
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
