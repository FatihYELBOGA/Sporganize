using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Enumerations;

namespace Sporganize.Services
{
    public interface ITeamService
    {
        public TeamResponse Add(TeamRequest request);
        public bool InvitePlayer(İnvitationRequest request);
        public bool UpdateStatus(InvitationUpdateRequest request);

    }

}
