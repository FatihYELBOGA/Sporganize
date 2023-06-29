using Sporganize.DTO;
using Sporganize.DTO.Requests;
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

        public TournamentResponse Add(TournamentRequest request)
        {
            string[] startDate = request.StartingDate.Split('-');
            string[] endDate = request.EndingDate.Split('-');

            Tournament tournament = new Tournament()
            {
                Name = request.Name,
                Title = request.Title,
                Description = request.Description,
                StartingDate = new DateTime((int)Int64.Parse(startDate[0]), (int)Int64.Parse(startDate[1]), (int)Int64.Parse(startDate[2])),
                EndingDate = new DateTime((int)Int64.Parse(endDate[0]), (int)Int64.Parse(endDate[1]), (int)Int64.Parse(endDate[2])),
                Branch = request.Branch
            };

            return new TournamentResponse(_tournamentRepository.Add(tournament));
        }

    }

}
