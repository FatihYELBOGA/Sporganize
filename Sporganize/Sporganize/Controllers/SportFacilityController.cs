using Microsoft.AspNetCore.Mvc;
using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Repositories;
using Sporganize.Services;

namespace Sporganize.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportFacilityController : ControllerBase
    {
        private readonly ISportFacilityService _sportFacilityService;

        public SportFacilityController(ISportFacilityService sportFacilityService)
        {
            _sportFacilityService = sportFacilityService;
        }

        [HttpGet("/sport-facilities/tournaments/{id}")]
        public List<TournamentResponse> GetTournamentsOfOwner(int id)
        {
            return _sportFacilityService.GetTournamentsOfOwner(id);
        }

        [HttpPost("/sport-facilities")]
        public SportFacilityResponse Add([FromForm] SportFacilityRequest request)
        {
            return _sportFacilityService.Add(request);
        }

    }

}
