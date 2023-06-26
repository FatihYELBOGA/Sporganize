using Sporganize.DTO.Responses;
using Sporganize.Repositories;

namespace Sporganize.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;
        public ProvinceService(IProvinceRepository provinceRepository) 
        {
            _provinceRepository = provinceRepository;
        }

        public List<ProvinceResponse> GetProvinces()
        {
            List<ProvinceResponse> provinceResponses = new List<ProvinceResponse>();
            foreach (var p in _provinceRepository.GetAll())
            {
                provinceResponses.Add(new ProvinceResponse()
                {
                    Id = p.Id,
                    Name = p.Name,
                });
            }

            return provinceResponses;
        }

    }

}
