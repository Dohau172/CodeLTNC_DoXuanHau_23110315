using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;

namespace PhoneStoreBUL.Interfaces
{
    public interface ISupplierBUS
    {

        Task<List<Supplier>> GetAll();
        Task<Supplier?> GetById(int id);
        Task<List<Supplier>> Search(string keyword);
        Task<bool> Add(SupplierCreateDTO dto);
        Task<bool> Update(SupplierUpdateDTO dto);
        Task<bool> Delete(int id);


    }
}
