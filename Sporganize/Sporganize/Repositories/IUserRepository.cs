using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public List<User> GetFriends(int userId);
        public List<UserTeams> GetTeams(int userId);
        public User GetAppointments(int userId);
        public User GetCaptainedTeams(int id);
        public List<TeamTournament> GetTournaments(int id);
        public List<SportFacility> GetSportsFacility(int id);   

    }

}
