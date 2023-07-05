using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Models;
using Sporganize.Repositories;

namespace Sporganize.Services
{
    public class SportFacilityService : ISportFacilityService
    {
        private readonly ISportFacilityRepository _sportFacilityRepository;
        public SportFacilityService(ISportFacilityRepository sportFacilityRepository)
        {
            _sportFacilityRepository = sportFacilityRepository;
        }

        public List<TournamentResponse> GetTournamentsOfOwner(int id)
        {
            List<TournamentResponse> tournamentResponses = new List<TournamentResponse>();
            foreach (var sf in _sportFacilityRepository.GetTournamentsOfOwner(id))
            {
                foreach (var t in sf.Tournaments)
                {
                    t.SportFacility.Street = sf.Street;
                    t.SportFacility.Street.District = sf.Street.District;
                    t.SportFacility.Street.District.Province = sf.Street.District.Province;
                    tournamentResponses.Add(new TournamentResponse(t));
                }
            }

            return tournamentResponses;
        }

        public SportFacilityResponse Add(SportFacilityRequest request)
        {
            SportFacility sportFacility = new SportFacility();
            sportFacility.Name = request.Name;
            sportFacility.Phone = request.Phone;
            sportFacility.OwnerId = request.OwnerId;
            sportFacility.StreetId = request.StreetId;

            Models.File profile = null;
            if (request.Profile.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    request.Profile.CopyTo(stream);
                    var bytes = stream.ToArray();

                    profile = new Models.File()
                    {
                        Name = request.Profile.FileName,
                        Type = request.Profile.ContentType,
                        Content = bytes
                    };
                }
            }
            sportFacility.Profile = profile;

            int id = _sportFacilityRepository.Add(sportFacility).Id;

            return new SportFacilityResponse(_sportFacilityRepository.GetById(id));
        }

    }

}
