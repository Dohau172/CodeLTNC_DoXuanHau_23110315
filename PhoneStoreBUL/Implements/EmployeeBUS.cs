using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;
using PhoneStoreBUL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class EmployeeBUS:IEmployeeBUS
    {
        private readonly IEmployeeDAO employeeDAO;
        public EmployeeBUS(IEmployeeDAO employeeDAO)
        {
            this.employeeDAO = employeeDAO;
        }
        public async Task<List<Employee>> GetAll()
        {
            return await employeeDAO.GetAll();
        }
        public async Task<Employee?> GetById(int id)
        {
            return await employeeDAO.GetById(id);
        }
        public async Task<List<Employee>> Search(string keyword)
        {
            return await employeeDAO.Search(keyword);
        }

        public async Task<bool> Add(EmployeeCreateDTO dto)
        {
            return await employeeDAO.Add(dto);
        }
        public async Task<bool> Update(EmployeeUpdateDTO dto)
        {
            return await employeeDAO.Update(dto);
        }
        public async Task<bool> Delete(int id)
        {
            return await employeeDAO.Delete(id);
        }
    }
}
