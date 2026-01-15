using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneStoreDAL.DTO;

namespace PhoneStoreBUL.Interfaces
{
    public interface IImeiUnitBUS
    {
        Task<List<ImeiUnitDTO>> GetAll();
        Task<ImeiUnitDTO?> GetByImei(string imei);
        Task<List<ImeiUnitDTO>> Search(string keyword);

        Task<bool> Add(ImeiUnitDTO dto);
        Task<bool> Update(ImeiUnitDTO dto);
        Task<bool> Delete(string imei);
    }
}
