using Microsoft.EntityFrameworkCore;
using Sporganize.Configurations;
using Sporganize.Generics;
using Sporganize.Models;
using Sporganize.Enumerations;

namespace Sporganize.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public override User GetById(int id)
        {
            return GetDataContext().users.
                Where(u => u.Id == id).
                Include(u => u.Profile).
                Include(t => t.Street).
                    ThenInclude(s => s.District).
                        ThenInclude(d => d.Province).
                FirstOrDefault();
        }

        public override List<User> GetAll()
        {
            return GetDataContext().users.
                Include(u => u.Profile).
                ToList();
        }

        public List<User> GetFriends(int userId)
        {
            User? user = GetDataContext().users.
                         Include(u => u.Profile).
                         Where(u => u.Id == userId).
                         Include(u => u.FirstFriends).
                            ThenInclude(uf => uf.SecondFriend).
                         Include(u => u.SecondFriends).
                            ThenInclude(uf => uf.FirstFriend).
                         FirstOrDefault();

            List<User> friendsOfUser = new List<User>();
            if(user != null)
            {
                foreach (var u in user.FirstFriends)
                {
                    friendsOfUser.Add(u.SecondFriend);
                }
                foreach (var u in user.SecondFriends)
                {
                    friendsOfUser.Add(u.FirstFriend);
                }
            }

            return friendsOfUser;
        }

        public List<UserTeams> GetTeams(int userId)
        {
            return GetDataContext().userTeams.
                Where(u => u.UserId == userId && u.Status == AppointmentStatus.APPROVED).
                Include(ut => ut.Team).
                    ThenInclude(t => t.Logo).
                Include(ut => ut.Team).
                    ThenInclude(t => t.Street).
                        ThenInclude(s => s.District).
                            ThenInclude(d => d.Province).
                Include(ut => ut.Team).
                    ThenInclude(t => t.Captain).
                Include(ut => ut.Team).
                    ThenInclude(t => t.Users).
                        ThenInclude(ut => ut.User).
                ToList();
        }

        public User GetCaptainedTeams(int id)
        {
            return GetDataContext().users.
                Where(u => u.Id == id).
                Include(ut => ut.TeamsToBeCaptain).
                    ThenInclude(t => t.Users).
                        ThenInclude(ut => ut.User).
                Include(u => u.TeamsToBeCaptain).
                    ThenInclude(t => t.Logo).
                Include(u => u.TeamsToBeCaptain).
                    ThenInclude(t => t.Street).
                        ThenInclude(s => s.District).
                            ThenInclude(d => d.Province).
                FirstOrDefault();
        }

        public User GetAppointments(int userId)
        {
            return GetDataContext().users.
                Where(u => u.Id == userId).
                Include(u => u.Profile).
                Include(u => u.Posts).
                    ThenInclude(p => p.Street).
                        ThenInclude(s => s.District).
                            ThenInclude(d => d.Province).
                Include(u => u.Posts).
                    ThenInclude(p => p.Users).
                        ThenInclude(u => u.AcceptedUser).
                FirstOrDefault();
        }

    }

}
