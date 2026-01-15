using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;
using PhoneStoreBUL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class ProductLineBUS:IProductLineBUS
    {
        private readonly IProductLineDAO productLineDao;
        public ProductLineBUS(IProductLineDAO productLineDao)
        {
            this.productLineDao = productLineDao;
        }

        public async Task<List<ProductLine>> GetAll()
        {
            return await productLineDao.GetAll();
        }

        public async Task<ProductLine?> GetById(int id)
        {
            return await productLineDao.GetById(id);
        }

        public async Task<List<ProductLine>> Search(string keyword)
        {
            return await productLineDao.Search(keyword);
        }

        public async Task<bool> Add(ProductLineCreateDTO dto)
        {
            return await productLineDao.Add(dto);
        }
        public async Task<bool> Update(ProductLineUpdateDTO dto)
        {
            return await productLineDao.Update(dto);
        }
        public async Task<bool> Delete(int id)
        {
            return await productLineDao.Delete(id);
        }
    }
}
