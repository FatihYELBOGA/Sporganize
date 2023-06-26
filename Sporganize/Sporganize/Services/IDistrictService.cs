using Sporganize.DTO.Responses;

namespace Sporganize.Services
{
    public interface IDistrictService
    {
        List<DistrictResponse> GetDistrictsByProvinceId(int provinceId);
    }
}
