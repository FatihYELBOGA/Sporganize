using Sporganize.Configurations;
using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

    }

}
