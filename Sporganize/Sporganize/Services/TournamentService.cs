using Sporganize.DTO;
using Sporganize.DTO.Responses;
using Sporganize.Models;
using Sporganize.Repositories;

namespace Sporganize.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        public TournamentService(ITournamentRepository tournamentRepository) { 
            _tournamentRepository = tournamentRepository;
        }

        public List<TournamentResponse> GetAllTournaments()
        {
            List<TournamentResponse> tournaments = new List<TournamentResponse>();
            foreach(var t in _tournamentRepository.GetAll())
            {
                tournaments.Add(new TournamentResponse(t));
            }

            return tournaments;
        }

        public TournamentResponse GetTournamentById(int id)
        {
            return new TournamentResponse(_tournamentRepository.GetById(id));
        }

        public List<LeagueResponse> GetLeagueById(int id)
        {
            List<LeagueResponse> leagueResponses = new List<LeagueResponse>();
            foreach (var l in _tournamentRepository.GetLeagueById(id))
            {
                leagueResponses.Add(new LeagueResponse(l));
            }

            return leagueResponses;
        }

    }

}
