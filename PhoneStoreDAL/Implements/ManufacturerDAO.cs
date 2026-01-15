using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;

namespace PhoneStoreDAL.Implements
{
    public class ManufacturerDAO:IManufacturerDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        public async Task<List<Manufacturer>> GetAll()
        {
            return await context.Manufacturers.ToListAsync();
        }
        public async Task<Manufacturer?> GetById(int id)
        {
            return await context.Manufacturers.FirstOrDefaultAsync(x => x.ManufacturerId == id);
        }
        public async Task<List<Manufacturer>> Search(string keyword)
        {
            keyword = (keyword ?? "").Trim();
            return await context.Manufacturers.Where(x => x.Name.Contains(keyword)).OrderBy(x=>x.ManufacturerId).ToListAsync();
        }

        public async Task<bool> Add(ManufacturerCreateDTO dto)
        {
            try
            {
                var name = (dto.Name ?? "").Trim();
                if (name.Length == 0) return false;

                await context.Manufacturers.AddAsync(new Manufacturer { Name = name });
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Update(ManufacturerUpdateDTO dto)
        {
            try
            {
                var s = await context.Manufacturers.FirstOrDefaultAsync(x => x.ManufacturerId == dto.ManufacturerId);
                if (s == null) return false;
                var name = (dto.Name ?? "").Trim();
                if (name.Length == 0) return false;
                s.Name = name;
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
                var e = await context.Manufacturers.FirstOrDefaultAsync(x => x.ManufacturerId == id);
                if (e == null) return false;

                context.Manufacturers.Remove(e);
                await context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
