using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;

namespace PhoneStoreBUL.Interfaces
{
    public interface IProductLineBUS
    {
        Task<List<ProductLine>> GetAll();
        Task<ProductLine?> GetById(int id);
        Task<List<ProductLine>> Search(string keyword);

        Task<bool> Add(ProductLineCreateDTO dto);
        Task<bool> Update(ProductLineUpdateDTO dto);
        Task<bool> Delete(int id);
    }
}
