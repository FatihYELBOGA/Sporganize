using Microsoft.AspNetCore.Mvc;
using Sporganize.DTO.Responses;
using Sporganize.Repositories;
using Sporganize.Services;

namespace Sporganize.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        private readonly IDistrictService _districtService;
        private readonly IStreetService _streetRepository;
        public LocationController(IProvinceService provinceService, IDistrictService districtService, IStreetService streetService) 
        {
            _provinceService = provinceService;
            _districtService = districtService;
            _streetRepository = streetService;
        }

        [HttpGet("/provinces")]
        public List<ProvinceResponse> GetProvinces()
        {
            return _provinceService.GetProvinces();
        }

        [HttpGet("/districts/{provinceId}")]
        public List<DistrictResponse> GetDistrictsByProvinceId(int provinceId)
        {
            return _districtService.GetDistrictsByProvinceId(provinceId);
        }

        [HttpGet("/streets/{districtId}")]
        public List<StreetResponse> GetStreetsByDistrictId(int districtId)
        {
            return _streetRepository.GetStreetsByDistrictId(districtId);
        }

    }

}
