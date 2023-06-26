using Sporganize.DTO.Responses;
using Sporganize.Repositories;

namespace Sporganize.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        } 

        public List<DistrictResponse> GetDistrictsByProvinceId(int provinceId)
        {
            List<DistrictResponse> districtResponses = new List<DistrictResponse>();
            foreach (var d in _districtRepository.GetDistrictsByProvinceId(provinceId))
            {
                districtResponses.Add(new DistrictResponse()
                {
                    Id = d.Id,
                    Name = d.Name,
                });
            }

            return districtResponses;
        }

    }
}
