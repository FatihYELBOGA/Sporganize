using Sporganize.DTO.Responses;

namespace Sporganize.Services
{
    public interface IUserService
    {
        public List<UserResponse> GetUsersWithoutDetails();

    }

}
