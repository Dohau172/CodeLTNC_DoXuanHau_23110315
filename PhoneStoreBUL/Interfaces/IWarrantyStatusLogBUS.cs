using System;
using System.Collections.Generic;
using System.Text;
using PhoneStoreDAL.Entities;

namespace PhoneStoreBUL.Interfaces
{
    public interface IWarrantyStatusLogBUS
    {
        Task<List<WarrantyStatusLog>> GetAll();
        Task<List<WarrantyStatusLog>> GetByTicketId(int warrantyTicketId);
        Task<WarrantyStatusLog?> GetById(int id);

        Task<bool> Add(WarrantyStatusLog entity);
        Task<bool> Update(WarrantyStatusLog entity);
        Task<bool> Delete(int id);
    }
}
