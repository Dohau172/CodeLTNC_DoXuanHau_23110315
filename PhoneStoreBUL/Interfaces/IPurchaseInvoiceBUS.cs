using System;
using System.Collections.Generic;
using System.Text;
using PhoneStoreDAL.Entities;

namespace PhoneStoreBUL.Interfaces
{
    public interface IPurchaseInvoiceBUS
    {
        Task<List<PurchaseInvoice>> GetAll();
        Task<PurchaseInvoice?> GetById(int id);
        Task<PurchaseInvoice?> GetByCode(string code);

        Task<bool> Add(PurchaseInvoice entity);
        Task<bool> Update(PurchaseInvoice entity);
        Task<bool> Delete(int id);

        // Nghiệp vụ có Transaction
        Task<bool> CreatePurchaseInvoiceWithDetails(PurchaseInvoice invoice, List<PurchaseInvoiceDetail> details);
    }
}
