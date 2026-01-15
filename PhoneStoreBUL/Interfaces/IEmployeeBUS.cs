using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;

namespace PhoneStoreBUL.Interfaces
{
    public interface IEmployeeBUS
    {
        Task<List<Employee>> GetAll();
        Task<Employee?> GetById(int id);
        Task<List<Employee>> Search(string keyword);

        Task<bool> Add(EmployeeCreateDTO dto);
        Task<bool> Update(EmployeeUpdateDTO dto);
        Task<bool> Delete(int id);
    }
}
