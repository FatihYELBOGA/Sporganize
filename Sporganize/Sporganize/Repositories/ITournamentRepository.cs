using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public interface ITournamentRepository : IGenericRepository<Tournament>
    {
        public Tournament GetTournamentById(int id);
    }
}
