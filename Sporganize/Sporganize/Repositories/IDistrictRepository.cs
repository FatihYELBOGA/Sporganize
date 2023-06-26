using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public interface IDistrictRepository : IGenericRepository<District>
    {
        public List<District> GetDistrictsByProvinceId(int provinceId);

    }

}
