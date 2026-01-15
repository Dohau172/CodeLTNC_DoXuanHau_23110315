using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;

namespace PhoneStoreDAL.Implements
{
    public class EmployeeDAO : IEmployeeDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        public async Task<List<Employee>> GetAll()
        {
            return await context.Employees.ToListAsync();
        }
        public async Task<Employee?> GetById(int id)
        {
            return await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
        }
        public async Task<List<Employee>> Search(string keyword)
        {
            keyword = (keyword ?? "").Trim();
            return await context.Employees
                .Where(x => x.FullName!.Contains(keyword) || x.Role!.Contains(keyword)).OrderBy(x => x.EmployeeId).ToListAsync();

        }

        public async Task<bool> Add(EmployeeCreateDTO dto)
        {
            try 
            { 
                var name = (dto.FullName ?? "").Trim();
                if (name.Length == 0) return false;
                var role = string.IsNullOrWhiteSpace(dto.Role) ? "Staff" : dto.Role.Trim();

                var s = new Employee
                {
                    FullName = name,
                    Role = role
                };
                await context.Employees.AddAsync(s);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Update(EmployeeUpdateDTO dto)
        {
            try
            {
                var s = await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == dto.EmployeeId);
                if (s == null) return false;
                var name = (dto.FullName ?? "").Trim();
                if (name.Length == 0) return false;
                var role = string.IsNullOrWhiteSpace(dto.Role) ? "Staff" : dto.Role.Trim();
                s.FullName = name;
                s.Role = role;
                context.Employees.Update(s);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var s = await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
                if (s == null) return false;
                context.Employees.Remove(s);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
