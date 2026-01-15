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
    public class ProductVariantDAO:IProductVariantDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        public async Task<List<ProductVariant>> GetAll()
        {
            return await context.ProductVariants.Include(pv => pv.ProductLine)
                .ToListAsync();
        }
        public async Task<ProductVariant?> GetById(int id)
        {
            return await context.ProductVariants
                .Include(pv => pv.ProductLine)
                .FirstOrDefaultAsync(pv => pv.ProductVariantId == id);
        }
        public async Task<List<ProductVariant>> Search(string keyword)
        {
            keyword = (keyword ?? "").Trim();
            return await context.ProductVariants.Include(x => x.ProductLine)
                .Where(x => x.Sku.Contains(keyword) || x.Color.Contains(keyword) ||
                            (x.ProductLine != null && x.ProductLine.Name.Contains(keyword)))
                .OrderBy(x => x.ProductVariantId)
                .ToListAsync();

        }

        public async Task<bool> Add(ProductVariantCreateDTO dto)
        {
            try
            {
                var sku = (dto.Sku ?? "").Trim();
                if (sku.Length == 0) return false;

                await context.ProductVariants.AddAsync(new ProductVariant
                {
                    ProductLineId = dto.ProductLineId,
                    Color = (dto.Color ?? "Unknown").Trim(),
                    StorageGb = dto.StorageGb,
                    Sku = sku,
                    SalePrice = dto.SalePrice,
                    QuantityInStock = 0
                });
                await  context.SaveChangesAsync();
                return true;
            }
            catch { return false; }

        }
        public async Task<bool> Update(ProductVariantUpdateDTO dto)
        {
            try
            {
                var e = await context.ProductVariants.FirstOrDefaultAsync(x => x.ProductVariantId == dto.ProductVariantId);
                if (e == null) return false;

                var sku = (dto.Sku ?? "").Trim();
                if (sku.Length == 0) return false;

                e.ProductLineId = dto.ProductLineId;
                e.Color = (dto.Color ?? "Unknown").Trim();
                e.StorageGb = dto.StorageGb;
                e.Sku = sku;
                e.SalePrice = dto.SalePrice;

                await context.SaveChangesAsync();
                return true;
            }
            catch { return false; }

        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var e = await context.ProductVariants.FirstOrDefaultAsync(x => x.ProductVariantId == id);
                if (e == null) return false;

                context.ProductVariants.Remove(e);
                await context.SaveChangesAsync();
                return true;
            }
            catch { return false; }

        }
    }
}
