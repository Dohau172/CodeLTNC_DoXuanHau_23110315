using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;

namespace PhoneStoreBUL.Interfaces
{
    public interface IProductVariantBUS
    {
        Task<List<ProductVariant>> GetAll();
        Task<ProductVariant?> GetById(int id);
        Task<List<ProductVariant>> Search(string keyword);

        Task<bool> Add(ProductVariantCreateDTO dto);
        Task<bool> Update(ProductVariantUpdateDTO dto);
        Task<bool> Delete(int id);
    }
}
