using System;
using System.Collections.Generic;
using System.Text;
using PhoneStoreDAL.Entities;

namespace PhoneStoreBUL.Interfaces
{
    public interface ISalesInvoiceDetailBUS
    {
        Task<List<SalesInvoiceDetail>> GetAll();
        Task<List<SalesInvoiceDetail>> GetBySalesInvoiceId(int salesInvoiceId);
        Task<SalesInvoiceDetail?> GetById(int id);

        Task<bool> Add(SalesInvoiceDetail entity);
        Task<bool> Update(SalesInvoiceDetail entity);
        Task<bool> Delete(int id);
    }
}
