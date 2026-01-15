using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhoneStoreDAL.Entities;

namespace PhoneStoreDAL.Interfaces
{
    public interface IPurchaseInvoiceDAO
    {
        Task<List<PurchaseInvoice>> GetAll();
        Task<PurchaseInvoice?> GetById(int id);
        Task<PurchaseInvoice?> GetByCode(string code);

        Task<bool> Add(PurchaseInvoice entity);
        Task<bool> Update(PurchaseInvoice entity);
        Task<bool> Delete(int id);
    }
}
