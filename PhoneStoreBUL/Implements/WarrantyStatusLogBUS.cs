using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreBUL.Interfaces;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class WarrantyStatusLogBUS : IWarrantyStatusLogBUS
    {
        private readonly IWarrantyStatusLogDAO dao;

        public WarrantyStatusLogBUS(IWarrantyStatusLogDAO dao)
        {
            this.dao = dao;
        }

        public Task<List<WarrantyStatusLog>> GetAll() => dao.GetAll();

        public Task<List<WarrantyStatusLog>> GetByTicketId(int warrantyTicketId)
            => dao.GetByTicketId(warrantyTicketId);

        public Task<WarrantyStatusLog?> GetById(int id) => dao.GetById(id);

        public Task<bool> Add(WarrantyStatusLog entity) => dao.Add(entity);

        public Task<bool> Update(WarrantyStatusLog entity) => dao.Update(entity);

        public Task<bool> Delete(int id) => dao.Delete(id);
    }
}
