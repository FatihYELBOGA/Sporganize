using Sporganize.Configurations;
using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public class DistrictRepository : GenericRepository<District>, IDistrictRepository
    {
        private readonly DataContext _dataContext;
        public DistrictRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public List<District> GetDistrictsByProvinceId(int provinceId)
        {
            return GetDataContext().districts.
                Where(d => d.ProvinceId == provinceId).
                ToList();
        }

    }

}
