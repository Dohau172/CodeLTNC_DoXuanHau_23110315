using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhoneStoreDAL.Entities;

namespace PhoneStoreDAL.Interfaces
{
    public interface ISalesInvoiceDAO
    {
        Task<List<SalesInvoice>> GetAll();
        Task<SalesInvoice?> GetById(int id);
        Task<SalesInvoice?> GetByCode(string code);

        Task<bool> Add(SalesInvoice entity);
        Task<bool> Update(SalesInvoice entity);
        Task<bool> Delete(int id);

    }
}
