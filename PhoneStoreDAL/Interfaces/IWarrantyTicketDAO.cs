using System;
using System.Collections.Generic;
using System.Text;
using PhoneStoreDAL.Entities;
using System.Threading.Tasks;

namespace PhoneStoreDAL.Interfaces
{
    public interface IWarrantyTicketDAO
    {
        Task<List<WarrantyTicket>> GetAll();
        Task<WarrantyTicket?> GetById(int id);
        Task<List<WarrantyTicket>> GetByImei(string imei);
        Task<WarrantyTicket?> GetByCode(string code);

        Task<bool> Add(WarrantyTicket entity);
        Task<bool> Update(WarrantyTicket entity);
        Task<bool> Delete(int id);

    }
}
