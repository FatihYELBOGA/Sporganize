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
            foreach(var i in _tournamentRepository.GetAll()){
                tournaments.Add(new TournamentResponse(i));
            }
            return tournaments;
        }
        public Tournament GetTournamentById(int id)
        {

            return _tournamentRepository.GetTournamentById(id);
        }
    }

}
