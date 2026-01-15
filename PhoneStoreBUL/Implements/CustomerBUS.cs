using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;
using PhoneStoreBUL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class CustomerBUS:ICustomerBUS
    {
        private readonly ICustomerDAO customerDAO;
        public CustomerBUS(ICustomerDAO customerDAO)
        {
            this.customerDAO = customerDAO;
        }
        public async Task<List<Customer>> GetAll()
        {
            return await customerDAO.GetAll();
        }
        public async Task<Customer?> GetById(int id)
        {
            return await customerDAO.GetById(id);
        }
        public async Task<List<Customer>> Search(string keyword)
        {
            return await customerDAO.Search(keyword);
        }
        public async Task<bool> Add(CustomerCreateDTO dto)
        {
            return await customerDAO.Add(dto);
        }
        public async Task<bool> Update(CustomerUpdateDTO dto)
        {
            return await customerDAO.Update(dto);
        }
        public async Task<bool> Delete(int id)
        {
            return await customerDAO.Delete(id);
        }
    }
}
