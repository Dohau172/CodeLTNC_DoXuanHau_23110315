using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;
using PhoneStoreBUL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class ManufacturerBUS:IManufacturerBUS
    {
        private readonly IManufacturerDAO manufacturerDao;
        public ManufacturerBUS(IManufacturerDAO manufacturerDao)
        {
            this.manufacturerDao = manufacturerDao;
        }
        public async Task<List<Manufacturer>> GetAll()
        {
            return await manufacturerDao.GetAll();
        }
        public async Task<Manufacturer?> GetById(int id)
        {
            return await manufacturerDao.GetById(id);
        }
        public async Task<List<Manufacturer>> Search(string keyword)
        {
            return await manufacturerDao.Search(keyword);
        }

        public async Task<bool> Add(ManufacturerCreateDTO dto)
        {
            return await manufacturerDao.Add(dto);
        }
        public async Task<bool> Update(ManufacturerUpdateDTO dto)
        {
            return await manufacturerDao.Update(dto);

        }
        public async Task<bool> Delete(int id)
        {
            return await manufacturerDao.Delete(id);
        }
    }
}
