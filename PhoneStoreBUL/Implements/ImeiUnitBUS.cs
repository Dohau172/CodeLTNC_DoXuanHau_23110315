using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Interfaces;
using PhoneStoreBUL.Interfaces;

namespace PhoneStoreBUL.Implements
{
    public class ImeiUnitBUS:IImeiUnitBUS
    {
        private readonly IImeiUnitDAO imeiUnitDAO;
        public ImeiUnitBUS(IImeiUnitDAO imeiUnitDAO)
        {
            this.imeiUnitDAO = imeiUnitDAO;
        }
        public async Task<List<ImeiUnitDTO>> GetAll()
        {
            return await imeiUnitDAO.GetAll();
        }
        public async Task<ImeiUnitDTO?> GetByImei(string imei)
        {
            return await imeiUnitDAO.GetByImei(imei);
        }
        public async Task<List<ImeiUnitDTO>> Search(string keyword)
        {
            return await imeiUnitDAO.Search(keyword);
        }

        public async Task<bool> Add(ImeiUnitDTO dto)
        {
            return await imeiUnitDAO.Add(dto);
        }
        public async Task<bool> Update(ImeiUnitDTO dto)
        {
            return await imeiUnitDAO.Update(dto);
        }
        public async Task<bool> Delete(string imei)
        {
            return await imeiUnitDAO.Delete(imei);
        }
    }
}
