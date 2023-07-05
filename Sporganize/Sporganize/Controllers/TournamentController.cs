using Microsoft.AspNetCore.Mvc;
using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Models;
using Sporganize.Services;

namespace Sporganize.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet("/tournaments")]
        public List<TournamentResponse> GetTournaments()
        {
            return _tournamentService.GetAllTournaments();
        }

        [HttpGet("/tournaments/{id}")]
        public TournamentResponse GetTournamentById(int id)
        {
            return _tournamentService.GetTournamentById(id);
        }

        [HttpGet("/tournaments/league/{id}")]
        public List<LeagueResponse> GetLeagueById( int id)
        {
            return _tournamentService.GetLeagueById(id);
        }

        [HttpPost("/tournaments")]
        public TournamentResponse Add(TournamentRequest request)
        {
            return _tournamentService.Add(request);
        }

        [HttpPost("/tournaments/league")]
        public List<LeagueResponse> AddMatch(MatchResultRequest request)
        {
            return _tournamentService.AddMatch(request);
        }

        [HttpPost("/tournaments/joining")]
        public List<LeagueResponse> AddTeam(JoiningTournamentRequest request)
        {
            return _tournamentService.AddTeam(request);
        }

    }

}
