using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sporganize.DTO;
using Sporganize.DTO.Requests;
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

        public UserResponse Update(UserRequest request, int id)
        {
            User user = _userRepository.GetById(id);
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Gender = request.Gender;

            string[] date = request.BornDate.Split('-');
            user.BornDate = new DateTime((int) Int64.Parse(date[0]), (int)Int64.Parse(date[1]), (int)Int64.Parse(date[2]));

            user.StreetId = request.StreetId;

            Models.File profile = null;
            if(request.Profile.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    request.Profile.CopyTo(stream);
                    var bytes = stream.ToArray();

                    profile = new Models.File()
                    {
                        Name = request.Profile.FileName,
                        Type = request.Profile.ContentType,
                        Content = bytes
                    };
                }
            }
            user.Profile = profile;

            return new UserResponse(_userRepository.Update(user));
        }

    }

}
