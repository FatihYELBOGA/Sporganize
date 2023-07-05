using Microsoft.EntityFrameworkCore;
using Sporganize.Configurations;
using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public class SportFacilityRepository : GenericRepository<SportFacility>, ISportFacilityRepository
    {
        public SportFacilityRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public List<SportFacility> GetTournamentsOfOwner(int id)
        {
            return GetDataContext().sportFacilities.
                Where(sf => sf.OwnerId == id).
                Include(sf => sf.Owner).
                Include(sf => sf.Street).
                    ThenInclude(s => s.District).
                        ThenInclude(d => d.Province).
                Include(sf => sf.Tournaments).
                ToList();
        }

        public override SportFacility GetById(int id)
        {
            return GetDataContext().sportFacilities.
                Where(sf => sf.Id == id).
                Include(sf => sf.Owner).
                Include(sf => sf.Profile).
                Include(sf => sf.Street).
                    ThenInclude(s => s.District).
                        ThenInclude(d => d.Province).
                FirstOrDefault();
        }

    }

}
