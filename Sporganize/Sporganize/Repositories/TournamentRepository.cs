using Microsoft.EntityFrameworkCore;
using Sporganize.Configurations;
using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public class TournamentRepository : GenericRepository<Tournament>, ITournamentRepository
    {
        private readonly DataContext _dataContext;
        public TournamentRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public Tournament GetTournamentById(int id) { 
            Tournament? tournament = _dataContext.tournaments.
                Where(t => t.Id == id).
                Include(t => t.Teams).
                    ThenInclude(t => t.Team).
                Include(m => m.Matches).
                    ThenInclude(mf => mf.TeamA).
                Include(m => m.Matches).
                    ThenInclude(ms => ms.TeamB).
                FirstOrDefault();
            return tournament;
        }
    }
}
