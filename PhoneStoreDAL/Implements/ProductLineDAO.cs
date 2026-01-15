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
    public class ProductLineDAO:IProductLineDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        public async Task<List<ProductLine>> GetAll()
        {
            return await context.ProductLines.ToListAsync();
        }
        public async Task<ProductLine?> GetById(int id)
        {
            return await context.ProductLines.FirstOrDefaultAsync(x => x.ProductLineId == id);
        }
        public async Task<List<ProductLine>> Search(string keyword)
        {
            keyword = (keyword ?? "").Trim().ToLower();
            return await context.ProductLines.Where(pl => pl.Name.ToLower().Contains(keyword)).OrderBy(pl=>pl.ProductLineId)
                .ToListAsync();
        }

        public async Task<bool> Add(ProductLineCreateDTO dto)
        {
            try
            {
                var name = (dto.Name ?? "").Trim();
                if (name.Length == 0) return false;
               await context.ProductLines.AddAsync(new ProductLine
               {
                   ManufacturerId = dto.ManufacturerId,
                   Name = name,
                    Description = dto.Description?.Trim()
                });
                
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Update(ProductLineUpdateDTO dto)
        {
            try
            {
                var e = await context.ProductLines.FirstOrDefaultAsync(x => x.ProductLineId == dto.ProductLineId);
                if (e == null) return false;

                var name = (dto.Name ?? "").Trim();
                if (name.Length == 0) return false;

                e.Name = name;
                e.Description = dto.Description?.Trim();
                e.ManufacturerId = dto.ManufacturerId;

                await context.SaveChangesAsync();
                return true;
            }
            catch { return false; }

        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var e = await context.ProductLines.FirstOrDefaultAsync(x => x.ProductLineId == id);
                if (e == null) return false;

                context.ProductLines.Remove(e);
                await context.SaveChangesAsync();
                return true;
            }
            catch { return false; }

        }
    }
}
