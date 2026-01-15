using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreBUL.Interfaces;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class PurchaseInvoiceDetailBUS : IPurchaseInvoiceDetailBUS
    {
        private readonly IPurchaseInvoiceDetailDAO dao;

        public PurchaseInvoiceDetailBUS(IPurchaseInvoiceDetailDAO dao)
        {
            this.dao = dao;
        }

        public Task<List<PurchaseInvoiceDetail>> GetAll() => dao.GetAll();

        public Task<List<PurchaseInvoiceDetail>> GetByPurchaseInvoiceId(int purchaseInvoiceId)
            => dao.GetByPurchaseInvoiceId(purchaseInvoiceId);

        public Task<PurchaseInvoiceDetail?> GetById(int id) => dao.GetById(id);

        public Task<bool> Add(PurchaseInvoiceDetail entity) => dao.Add(entity);

        public Task<bool> Update(PurchaseInvoiceDetail entity) => dao.Update(entity);

        public Task<bool> Delete(int id) => dao.Delete(id);
    }
}
