using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreDAL.Interfaces
{
    public interface IProductLineDAO
    {
        Task<List<ProductLine>> GetAll();
        Task<ProductLine?> GetById(int id);
        Task<List<ProductLine>> Search(string keyword);

        Task<bool> Add(ProductLineCreateDTO dto);
        Task<bool> Update(ProductLineUpdateDTO dto);
        Task<bool> Delete(int id);

    }
}
