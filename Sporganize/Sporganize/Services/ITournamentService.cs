using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Models;

namespace Sporganize.Services
{
    public interface ITournamentService
    {
        public List<TournamentResponse> GetAllTournaments();
        public TournamentResponse GetTournamentById(int id);
        public List<LeagueResponse> GetLeagueById(int id);
        public TournamentResponse Add(TournamentRequest request);
        public List<LeagueResponse> AddMatch(MatchResultRequest request);
        public List<LeagueResponse> AddTeam(JoiningTournamentRequest request);
        public List<TeamResponse> GetTeamsById(int id);

    }

}
