using Microsoft.AspNetCore.Mvc;
using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
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

    }

}
