using Microsoft.EntityFrameworkCore;
using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PhoneStoreDAL.Entities.Enums;

namespace PhoneStoreDAL.Implements
{
    public class ImeiUnitDAO:IImeiUnitDAO
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
      
        public async Task<List<ImeiUnitDTO>> GetAll()
        {
            return await context.ImeiUnits
        .Select(x => new ImeiUnitDTO
        {
            Imei = x.Imei,
            ProductVariantId = x.ProductVariantId,
            Status = (int)x.Status,
            SoldAt = x.SoldAt,
            WarrantyStartDate = x.WarrantyStartDate,
            WarrantyMonths = x.WarrantyMonths
        })
        .ToListAsync();

        }
        public async Task<ImeiUnitDTO?> GetByImei(string imei)
        {
            imei = (imei ?? "").Trim();

            return await context.ImeiUnits
                .Where(x => x.Imei == imei)
                .Select(x => new ImeiUnitDTO
                {
                    Imei = x.Imei,
                    ProductVariantId = x.ProductVariantId,
                    Status = (int)x.Status,
                    SoldAt = x.SoldAt,
                    WarrantyStartDate = x.WarrantyStartDate,
                    WarrantyMonths = x.WarrantyMonths
                })
                .FirstOrDefaultAsync();
        }
        public async Task<List<ImeiUnitDTO>> Search(string keyword)
        {
            keyword = (keyword ?? "").Trim();

            return await context.ImeiUnits
                .Where(x => x.Imei.Contains(keyword))
                .Select(x => new ImeiUnitDTO
                {
                    Imei = x.Imei,
                    ProductVariantId = x.ProductVariantId,
                    Status = (int)x.Status,
                    SoldAt = x.SoldAt,
                    WarrantyStartDate = x.WarrantyStartDate,
                    WarrantyMonths = x.WarrantyMonths
                })
                .ToListAsync();

        } 

        public async Task<bool> Add(ImeiUnitDTO dto)
        {
            try
            {
                var imei = (dto.Imei ?? "").Trim();
                if (imei.Length == 0) return false;

                var exists = await context.ImeiUnits.AnyAsync(x => x.Imei == imei);
                if (exists) return false;

                await context.ImeiUnits.AddAsync(new ImeiUnit
                {
                    Imei = imei,
                    ProductVariantId = dto.ProductVariantId,
                    Status = (ImeiStatus)dto.Status,
                    SoldAt = dto.SoldAt,
                    WarrantyStartDate = dto.WarrantyStartDate,
                    WarrantyMonths = dto.WarrantyMonths <= 0 ? 12 : dto.WarrantyMonths
                });

                await context.SaveChangesAsync();
                return true;
            }
            catch { return false; }

        }
        public async Task<bool> Update(ImeiUnitDTO dto)
        {
            try
            {
                var imei = (dto.Imei ?? "").Trim();
                if (imei.Length == 0) return false;

                var e = await context.ImeiUnits.FirstOrDefaultAsync(x => x.Imei == imei);
                if (e == null) return false;

                e.ProductVariantId = dto.ProductVariantId;
                e.Status = (ImeiStatus)dto.Status;
                e.SoldAt = dto.SoldAt;
                e.WarrantyStartDate = dto.WarrantyStartDate;
                e.WarrantyMonths = dto.WarrantyMonths <= 0 ? 12 : dto.WarrantyMonths;

                await context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Delete(string imei)
        {
            try
            {
                imei = (imei ?? "").Trim();
                var e = await context.ImeiUnits.FirstOrDefaultAsync(x => x.Imei == imei);
                if (e == null) return false;

                context.ImeiUnits.Remove(e);
                await context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
