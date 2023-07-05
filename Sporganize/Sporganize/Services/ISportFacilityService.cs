using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;

namespace Sporganize.Services
{
    public interface ISportFacilityService
    {
        public SportFacilityResponse Add(SportFacilityRequest request);
        public List<TournamentResponse> GetTournamentsOfOwner(int id);

    }

}
