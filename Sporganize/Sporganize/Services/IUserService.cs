using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Models;

namespace Sporganize.Services
{
    public interface IUserService
    {
        public List<UserResponse> GetWithoutDetails();
        public UserResponse GetById(int id);
        public List<UserResponse> GetFriends(int id);
        public List<TeamResponse> GetTeams(int id);
        public List<AppointmentResponse> GetAppointments(int id);
        public UserResponse Update(UserRequest request, int id);
        public List<TeamResponse> GetCaptainedTeams(int id);
        public List<TournamentResponse> GetTournamentsByTeamId(int teamId);
        public List<InvitationResponse> GetInvitations(int id);
        public AppointmentResponse AcceptAppointment(int id, int appointmentId);

    }

}
