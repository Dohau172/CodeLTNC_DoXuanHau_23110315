using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreDAL.Interfaces
{
    public interface IEmployeeDAO
    {
        Task<List<Employee>> GetAll();
        Task<Employee?> GetById(int id);
        Task<List<Employee>> Search(string keyword);

        Task<bool> Add(EmployeeCreateDTO dto);
        Task<bool> Update(EmployeeUpdateDTO dto);
        Task<bool> Delete(int id);
    }
}
