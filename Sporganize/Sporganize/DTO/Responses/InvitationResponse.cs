using Sporganize.Enumerations;
using Sporganize.Models;

namespace Sporganize.DTO.Responses
{
    public class InvitationResponse
    {
        public int Id { get; set; } 
        public UserResponse User { get; set; }
        public TeamResponse Team { get; set; }
        public AppointmentStatus Status { get; set; }

        public InvitationResponse(UserTeams userTeam)
        {
            Id = userTeam.Id;
            User = new UserResponse(userTeam.User);
            Team = new TeamResponse(userTeam.Team);
            Status = userTeam.Status;
        }

    }

}
