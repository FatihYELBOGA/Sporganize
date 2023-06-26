using Sporganize.DTO.Responses;

namespace Sporganize.Services
{
    public interface IStreetService
    {
        List<StreetResponse> GetStreetsByDistrictId(int districtId);

    }
}
