using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sporganize.DTO;
using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Models;
using Sporganize.Repositories;
using Sporganize.Enumerations;
using Microsoft.EntityFrameworkCore;

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
                ut.Team.Users = ut.Team.Users.Where(ut => ut.Status == AppointmentStatus.APPROVED).ToList();
                teamResponses.Add(new TeamResponse(ut.Team));
            }

            return teamResponses;
        }

        public List<TeamResponse> GetCaptainedTeams(int id)
        {
            List<TeamResponse> teamResponses = new List<TeamResponse>();
            foreach (var ut in _userRepository.GetCaptainedTeams(id).TeamsToBeCaptain)
            {
                ut.Users = ut.Users.Where(ut => ut.Status == AppointmentStatus.APPROVED).ToList();
                teamResponses.Add(new TeamResponse(ut));
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

        public List<TournamentResponse> GetTournamentsByTeamId(int teamId)
        {
            List<TournamentResponse> tournamentResponses = new List<TournamentResponse>();
            foreach (var tt in _userRepository.GetTournaments(teamId))
            {
                tournamentResponses.Add(new TournamentResponse(tt.Tournament));
            }

            return tournamentResponses;
        }

        public List<InvitationResponse> GetInvitations(int id)
        {
            List<UserTeams> invitations = _userRepository.GetDataContext().userTeams.
                Where(ut => ut.UserId == id && ut.Status == Enumerations.AppointmentStatus.WAITING).
                Include(ut => ut.User).
                Include(ut => ut.Team).
                ToList();

            List<InvitationResponse> invitationResponses = new List<InvitationResponse>();
            foreach (var i in invitations)
            {
                invitationResponses.Add(new InvitationResponse(i));
            }

            return invitationResponses;
        }

        public AppointmentResponse AcceptAppointment(int id, int appointmentId)
        {
            _userRepository.GetDataContext().userAppointments.Add(new UserAppointment()
            {
                AcceptedUserId = id,
                AppointmentId = appointmentId,
            });
            _userRepository.GetDataContext().SaveChanges();

            return new AppointmentResponse(
                _userRepository.GetDataContext().appointments.
                Where(a => a.Id == appointmentId).
                Include(a => a.User).
                    ThenInclude(u => u.Profile).
                Include(a => a.Street).
                    ThenInclude(s => s.District).
                        ThenInclude(d => d.Province).
                Include(a => a.Users).
                    ThenInclude(u => u.AcceptedUser).
                    ThenInclude(u => u.Profile).
                FirstOrDefault());
        }

        public List<SportFacilityResponse> GetSportFacilities(int id)
        {
            List<SportFacilityResponse> sportFacilityResponses = new List<SportFacilityResponse>(); 
            foreach (var sf in _userRepository.GetSportsFacility(id))
            {
                sportFacilityResponses.Add(new SportFacilityResponse(sf));
            }

            return sportFacilityResponses;
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
