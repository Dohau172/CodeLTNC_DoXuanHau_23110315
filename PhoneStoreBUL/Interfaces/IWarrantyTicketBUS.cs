using System;
using System.Collections.Generic;
using System.Text;
using PhoneStoreDAL.Entities;
using static PhoneStoreDAL.Entities.Enums;

namespace PhoneStoreBUL.Interfaces
{
    public interface IWarrantyTicketBUS
    {
        Task<List<WarrantyTicket>> GetAll();
        Task<WarrantyTicket?> GetById(int id);
        Task<List<WarrantyTicket>> GetByImei(string imei);
        Task<WarrantyTicket?> GetByCode(string code);

        Task<bool> Add(WarrantyTicket entity);
        Task<bool> Update(WarrantyTicket entity);
        Task<bool> Delete(int id);

        // Nghiệp vụ có Transaction: đổi status + add log
        Task<bool> ChangeWarrantyStatus(int ticketId, WarrantyStatus newStatus, int changedByEmployeeId, string? note);
    }
}
