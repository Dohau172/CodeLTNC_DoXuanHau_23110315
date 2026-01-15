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
    public class SupplierDAO:ISupplierDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        public async Task<List<Supplier>> GetAll()
        {
            return await context.Suppliers.ToListAsync();
        }
        public async Task<Supplier?> GetById(int id)
        {
            return await context.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == id);
        }
        public async Task<List<Supplier>> Search(string keyword)
        {
            keyword = (keyword ?? "").Trim().ToLower();
            return await context.Suppliers.Where(x => x.Name.ToLower().Contains(keyword)).OrderBy(x => x.SupplierId).ToListAsync();
        }

        public async Task<bool> Add(SupplierCreateDTO dto)
        {
            try
            {
                var name = (dto.Name ?? "").Trim();
                if (name.Length == 0) return false;

                await context.Suppliers.AddAsync(new Supplier()
                {
                    Name = name,
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
        public async Task<bool> Update(SupplierUpdateDTO dto)
        {
            try
            {
                var e = await context.Suppliers.FindAsync(dto.SupplierId);
                if (e == null) return false;    
                var name = (dto.Name ?? "").Trim();
                if (name.Length == 0) return false;

                e.Name = name;
                e.Phone = dto.Phone?.Trim();
                e.Email = dto.Email?.Trim();
                e.Address = dto.Address?.Trim();

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
                var e = await context.Suppliers.FindAsync(id);
                if (e == null) return false;
                context.Suppliers.Remove(e);
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
