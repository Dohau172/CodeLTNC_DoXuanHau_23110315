using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using PhoneStoreDAL.Interfaces;
using PhoneStoreBUL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class SupplierBUS:ISupplierBUS
    {
        private readonly ISupplierDAO supplierDao;
        public SupplierBUS(ISupplierDAO supplierDao)
        {
            this.supplierDao = supplierDao;
        }
        public async Task<List<Supplier>> GetAll()
        {
            return await supplierDao.GetAll();
        }
        public async Task<Supplier?> GetById(int id)
        {
            return await supplierDao.GetById(id);

        }
        public async Task<List<Supplier>> Search(string keyword)
        {
            return await supplierDao.Search(keyword);
        }
        public async Task<bool> Add(SupplierCreateDTO dto)
        {
            return await supplierDao.Add(dto);
        }
        public async Task<bool> Update(SupplierUpdateDTO dto)
        {
            return await supplierDao.Update(dto);
        }
        public async Task<bool> Delete(int id)
        {
            return await supplierDao.Delete(id);
        }

    }
}
