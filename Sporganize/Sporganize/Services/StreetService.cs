using Sporganize.DTO.Responses;
using Sporganize.Repositories;

namespace Sporganize.Services
{
    public class StreetService : IStreetService
    {
        private readonly IStreetRepository _streetRepository;
        public StreetService(IStreetRepository streetRepository)
        {
            _streetRepository = streetRepository;
        }

        public List<StreetResponse> GetStreetsByDistrictId(int districtId)
        {
            List<StreetResponse> streetResponses = new List<StreetResponse>();
            foreach (var s in _streetRepository.GetStreetsByDistrictId(districtId))
            {
                streetResponses.Add(new StreetResponse()
                {
                    Id = s.Id,
                    Name = s.Name,
                });
            }

            return streetResponses;
        }

    }

}
