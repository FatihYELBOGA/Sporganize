using Sporganize.DTO;
using Sporganize.DTO.Responses;
using Sporganize.Models;
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

        public List<UserResponse> GetWithoutDetails()
        {
            List<UserResponse> userResponses = new List<UserResponse>();
            foreach (var user in _userRepository.GetAll())
            {
                userResponses.Add(new UserResponse(user));
            }

            return userResponses;
        }

        public UserResponse GetById(int id)
        {
            return new UserResponse(_userRepository.GetById(id));
        }

        public List<UserResponse> GetFriends(int id)
        {
            List<UserResponse> userResponses = new List<UserResponse>();
            foreach (var user in _userRepository.GetFriends(id))
            {
                userResponses.Add(new UserResponse(user));
            }

            return userResponses;
        }

        public List<TeamResponse> GetTeams(int id)
        {
            List<TeamResponse> teamResponses = new List<TeamResponse>();
            foreach (var ut in _userRepository.GetTeams(id))
            {
                teamResponses.Add(new TeamResponse(ut.Team));
            }

            return teamResponses;
        }

        public List<AppointmentResponse> GetAppointments(int id)
        {
            List<AppointmentResponse> appointmentResponses = new List<AppointmentResponse>();
            foreach (var post in _userRepository.GetAppointments(id).Posts)
            {
                appointmentResponses.Add(new AppointmentResponse(post));
            }

            return appointmentResponses;
        }
    }
}
