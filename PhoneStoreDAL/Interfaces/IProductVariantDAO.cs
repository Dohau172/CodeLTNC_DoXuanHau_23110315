using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreDAL.Interfaces
{
    public interface IProductVariantDAO
    {
        Task<List<ProductVariant>> GetAll();
        Task<ProductVariant?> GetById(int id);
        Task<List<ProductVariant>> Search(string keyword);

        Task<bool> Add(ProductVariantCreateDTO dto);
        Task<bool> Update(ProductVariantUpdateDTO dto);
        Task<bool> Delete(int id);

    }
}
