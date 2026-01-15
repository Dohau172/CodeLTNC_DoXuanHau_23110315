using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;

namespace PhoneStoreBUL.Interfaces
{
    public interface ICustomerBUS
    {
        Task<List<Customer>> GetAll();
        Task<Customer?> GetById(int id);
        Task<List<Customer>> Search(string keyword);

        Task<bool> Add(CustomerCreateDTO dto);
        Task<bool> Update(CustomerUpdateDTO dto);
        Task<bool> Delete(int id);
    }
}
