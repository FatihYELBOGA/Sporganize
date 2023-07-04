using Microsoft.AspNetCore.Mvc;
using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Enumerations;
using Sporganize.Services;

namespace Sporganize.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController :  ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost("/teams")]
        public TeamResponse Add([FromForm] TeamRequest request)
        {
            return _teamService.Add(request);
        }

        [HttpPost("/teams/invitation")]
        public bool InvitePlayer(İnvitationRequest request)
        {
            return _teamService.InvitePlayer(request);
        }

        [HttpPut("/teams/invitation")]
        public bool UpdateStatus([FromForm] InvitationUpdateRequest request)
        {
            return _teamService.UpdateStatus(request);
        }

    }

}
