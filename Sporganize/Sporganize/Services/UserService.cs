using Sporganize.DTO;
using Sporganize.DTO.Responses;
using Sporganize.Repositories;

namespace Sporganize.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserResponse> GetUsersWithoutDetails()
        {
            List<UserResponse> userResponses = new List<UserResponse>();
            foreach (var user in _userRepository.GetAll())
            {
                userResponses.Add(ConvertToDto.ToUserResponse(user));
            }

            return userResponses;
        }

    }

}
