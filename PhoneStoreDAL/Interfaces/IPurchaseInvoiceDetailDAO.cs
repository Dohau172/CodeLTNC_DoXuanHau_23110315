using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhoneStoreDAL.Entities;

namespace PhoneStoreDAL.Interfaces
{
    public interface IPurchaseInvoiceDetailDAO
    {
        Task<List<PurchaseInvoiceDetail>> GetAll();
        Task<List<PurchaseInvoiceDetail>> GetByPurchaseInvoiceId(int purchaseInvoiceId);
        Task<PurchaseInvoiceDetail?> GetById(int id);

        Task<bool> Add(PurchaseInvoiceDetail entity);
        Task<bool> Update(PurchaseInvoiceDetail entity);
        Task<bool> Delete(int id);
    }
}
