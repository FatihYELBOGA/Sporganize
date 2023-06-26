using Sporganize.Configurations;
using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public class StreetRepository : GenericRepository<Street>, IStreetRepository
    {
        private readonly DataContext _dataContext;
        public StreetRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public List<Street> GetStreetsByDistrictId(int districtId)
        {
            return GetDataContext().streets.
                Where(s => s.DistrictId == districtId).
                ToList();
        }

    }

}
