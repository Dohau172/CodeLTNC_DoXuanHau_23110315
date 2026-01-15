using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreDAL.Interfaces
{
    public interface ICustomerDAO
    {
        Task<List<Customer>> GetAll();
        Task<Customer?> GetById(int id);
        Task<List<Customer>> Search(string keyword);

        Task<bool> Add(CustomerCreateDTO dto);
        Task<bool> Update(CustomerUpdateDTO dto);
        Task<bool> Delete(int id);

    }
}
