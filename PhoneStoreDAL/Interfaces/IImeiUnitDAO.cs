using PhoneStoreDAL.DTO;
using PhoneStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreDAL.Interfaces
{
    public interface IImeiUnitDAO
    {
        Task<List<ImeiUnitDTO>> GetAll();
        Task<ImeiUnitDTO?> GetByImei(string imei);
        Task<List<ImeiUnitDTO>> Search(string keyword); // tìm theo imei / sku / trạng thái (tùy implement)

        Task<bool> Add(ImeiUnitDTO dto);
        Task<bool> Update(ImeiUnitDTO dto);
        Task<bool> Delete(string imei);
    }
}
