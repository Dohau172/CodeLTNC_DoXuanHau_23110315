using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreBUL.Interfaces;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class SalesInvoiceDetailBUS : ISalesInvoiceDetailBUS
    {
        private readonly ISalesInvoiceDetailDAO dao;

        public SalesInvoiceDetailBUS(ISalesInvoiceDetailDAO dao)
        {
            this.dao = dao;
        }

        public Task<List<SalesInvoiceDetail>> GetAll() => dao.GetAll();

        public Task<List<SalesInvoiceDetail>> GetBySalesInvoiceId(int salesInvoiceId)
            => dao.GetBySalesInvoiceId(salesInvoiceId);

        public Task<SalesInvoiceDetail?> GetById(int id) => dao.GetById(id);

        public Task<bool> Add(SalesInvoiceDetail entity) => dao.Add(entity);

        public Task<bool> Update(SalesInvoiceDetail entity) => dao.Update(entity);

        public Task<bool> Delete(int id) => dao.Delete(id);
    }
}
