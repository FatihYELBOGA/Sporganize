using Microsoft.EntityFrameworkCore;
using Sporganize.Configurations;
using Sporganize.DTO.Responses;
using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public class TournamentRepository : GenericRepository<Tournament>, ITournamentRepository
    {

        public TournamentRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public List<TeamTournament> GetLeagueById(int id)
        {
            return GetDataContext().teamTournaments.
                Where(tt => tt.TournamentId == id).
                Include(tt => tt.Tournament).
                Include(tt => tt.Team).
                    ThenInclude(t => t.Logo).
                ToList();
        }

    }

}
