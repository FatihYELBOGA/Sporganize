using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public interface ISportFacilityRepository : IGenericRepository<SportFacility>
    {
        public List<SportFacility> GetTournamentsOfOwner(int id);

    }

}
