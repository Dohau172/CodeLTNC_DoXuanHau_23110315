using System;
using System.Collections.Generic;
using System.Text;
using PhoneStoreDAL.Entities;

namespace PhoneStoreBUL.Interfaces
{
    public interface IPurchaseInvoiceDetailBUS
    {
        Task<List<PurchaseInvoiceDetail>> GetAll();
        Task<List<PurchaseInvoiceDetail>> GetByPurchaseInvoiceId(int purchaseInvoiceId);
        Task<PurchaseInvoiceDetail?> GetById(int id);

        Task<bool> Add(PurchaseInvoiceDetail entity);
        Task<bool> Update(PurchaseInvoiceDetail entity);
        Task<bool> Delete(int id);
    }
}
