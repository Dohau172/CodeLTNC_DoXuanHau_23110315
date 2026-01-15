using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace PhoneStoreDAL.Interfaces
{
    public interface IManufacturerDAO
    {
        Task<List<Manufacturer>> GetAll();
        Task<Manufacturer?> GetById(int id);
        Task<List<Manufacturer>> Search(string keyword);

        Task<bool> Add(ManufacturerCreateDTO dto);
        Task<bool> Update(ManufacturerUpdateDTO dto);
        Task<bool> Delete(int id);
    }
}
