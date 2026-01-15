using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneStoreBUL.Interfaces;
using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;
using static PhoneStoreDAL.Entities.Enums;

namespace PhoneStoreBUL.Implements
{
    public class WarrantyTicketBUS : IWarrantyTicketBUS
    {
        private readonly IWarrantyTicketDAO ticketDao;

        public WarrantyTicketBUS(IWarrantyTicketDAO ticketDao)
        {
            this.ticketDao = ticketDao;
        }

        public Task<List<WarrantyTicket>> GetAll() => ticketDao.GetAll();

        public Task<WarrantyTicket?> GetById(int id) => ticketDao.GetById(id);

        public Task<List<WarrantyTicket>> GetByImei(string imei) => ticketDao.GetByImei(imei);

        public Task<WarrantyTicket?> GetByCode(string code) => ticketDao.GetByCode(code);

        public Task<bool> Add(WarrantyTicket entity) => ticketDao.Add(entity);

        public Task<bool> Update(WarrantyTicket entity) => ticketDao.Update(entity);

        public Task<bool> Delete(int id) => ticketDao.Delete(id);

        // ===== Transaction nghiệp vụ =====
        public async Task<bool> ChangeWarrantyStatus(int ticketId, WarrantyStatus newStatus, int changedByEmployeeId, string? note)
        {
            if (ticketId <= 0) return false;
            if (changedByEmployeeId <= 0) return false;

            using var db = new PhoneStoreDBContext();
            using var tx = await db.Database.BeginTransactionAsync();

            try
            {
                var ticket = await db.WarrantyTickets.FirstOrDefaultAsync(x => x.WarrantyTicketId == ticketId);
                if (ticket == null) return false;

                ticket.CurrentStatus = newStatus;

                var log = new WarrantyStatusLog
                {
                    WarrantyTicketId = ticketId,
                    Status = newStatus,
                    ChangedAt = DateTime.UtcNow,
                    ChangedByEmployeeId = changedByEmployeeId,
                    Note = note
                };

                db.WarrantyStatusLogs.Add(log);

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
