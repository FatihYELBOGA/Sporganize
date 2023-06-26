using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public interface IStreetRepository : IGenericRepository<Street>
    {
        List<Street> GetStreetsByDistrictId(int districtId);

    }

}
