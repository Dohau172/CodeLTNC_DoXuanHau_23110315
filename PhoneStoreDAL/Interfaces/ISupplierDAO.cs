using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;     
using System.Threading.Tasks;

namespace PhoneStoreDAL.Interfaces
{
    public interface ISupplierDAO
    {
        Task<List<Supplier>> GetAll();
        Task<Supplier?> GetById(int id);
        Task<List<Supplier>> Search(string keyword);

        Task<bool> Add(SupplierCreateDTO dto);
        Task<bool> Update(SupplierUpdateDTO dto);
        Task<bool> Delete(int id);

    }
}
