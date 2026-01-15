using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.Entities;
namespace PhoneStoreBUL.Interfaces
{
    public interface ISalesInvoiceBUS
    {
        Task<List<SalesInvoice>> GetAll();
        Task<SalesInvoice?> GetById(int id);
        Task<SalesInvoice?> GetByCode(string code);

        Task<bool> Add(SalesInvoice entity);
        Task<bool> Update(SalesInvoice entity);
        Task<bool> Delete(int id);

        // Nghiệp vụ có Transaction
        Task<bool> CreateSalesInvoiceWithImeis(SalesInvoice invoice, List<string> imeis);
    }
}
