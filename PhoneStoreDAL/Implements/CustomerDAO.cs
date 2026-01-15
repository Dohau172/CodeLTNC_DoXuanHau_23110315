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
    public class CustomerDAO : ICustomerDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();

        public async Task<List<Customer>> GetAll()
        {
            return await context.Customers.ToListAsync();
        }
        public async Task<Customer?> GetById(int id)
        {
            return await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
        }
        public async Task<List<Customer>> Search(string keyword)
        {
            keyword = (keyword ?? "").Trim().ToLower();
            return await context.Customers.Where(x=>x.FullName.Contains(keyword) || (x.Phone ?? "").Contains(keyword) || (x.Email ?? "").Contains(keyword)).OrderBy(x=>x.CustomerId).ToListAsync();
        }

        public async Task<bool> Add(CustomerCreateDTO dto)
        {
            try
            {
                var name = (dto.FullName ?? "").Trim();
                if (name.Length == 0) return false;

               await context.Customers.AddAsync(new Customer
               {
                    FullName = name,
                    Phone = dto.Phone?.Trim(),
                    Email = dto.Email?.Trim(),
                    Address = dto.Address?.Trim()
                });
                
                await context.SaveChangesAsync();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Update(CustomerUpdateDTO entity)
        {
            try
            {
                var s = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == entity.CustomerId);
                if (s == null) return false;
                var name = (entity.FullName ?? "").Trim();
                if (name.Length == 0) return false;
                s.FullName = name;
                s.Phone = entity.Phone?.Trim();
                s.Email = entity.Email?.Trim();
                s.Address = entity.Address?.Trim();

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
                var entity = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
                if (entity == null) return false;
                context.Customers.Remove(entity);
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
