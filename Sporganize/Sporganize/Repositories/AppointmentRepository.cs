using Microsoft.EntityFrameworkCore;
using Sporganize.Configurations;
using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {

        public AppointmentRepository(DataContext dataContext) : base(dataContext)
        {

        }
        
        public override List<Appointment> GetAll()
        {
            return GetDataContext().appointments.
                Include(a => a.User).
                    ThenInclude(u => u.Profile).
                Include(a => a.Street).
                    ThenInclude(s => s.District).
                        ThenInclude(d => d.Province).
                Include(a => a.Users).
                    ThenInclude(u => u.AcceptedUser).
                ToList();
        }
    }

}
