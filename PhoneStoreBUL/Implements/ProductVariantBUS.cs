using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;
using PhoneStoreBUL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class ProductVariantBUS:IProductVariantBUS
    {
        private readonly IProductVariantDAO productVariantDAO;
        public ProductVariantBUS(IProductVariantDAO productVariantDAO) 
        {
            this.productVariantDAO = productVariantDAO;
        }
        public async Task<List<ProductVariant>> GetAll()
        {
            return await productVariantDAO.GetAll();
        }

        public async Task<ProductVariant?> GetById(int id)
        {
            return await productVariantDAO.GetById(id);
        }

        public async Task<List<ProductVariant>> Search(string keyword)
        {
            return await productVariantDAO.Search(keyword);
        }

        public async Task<bool> Add(ProductVariantCreateDTO dto)
        {
            return await productVariantDAO.Add(dto);
        }

        public async Task<bool> Update(ProductVariantUpdateDTO dto)
        {
            return await productVariantDAO.Update(dto);
        }

        public async Task<bool> Delete(int id)
        {
            return await productVariantDAO.Delete(id);
        }
    }
}
