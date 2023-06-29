using Microsoft.EntityFrameworkCore;
using Sporganize.Configurations;
using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public override Team GetById(int id)
        {
            return GetDataContext().teams.
                Where(t => t.Id == id).
                Include(t => t.Logo).
                Include(t => t.Captain).
                    ThenInclude(u => u.Profile).
                Include(t => t.Street).
                    ThenInclude(s => s.District).
                        ThenInclude(d => d.Province).
                Include(t => t.Users).
                    ThenInclude(ut => ut.User).
                        ThenInclude(u => u.Profile).
                FirstOrDefault();
        }

    }

}
