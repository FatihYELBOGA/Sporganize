using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;

namespace Sporganize.Services
{
    public interface ITeamService
    {
        public TeamResponse Add(TeamRequest request);

    }

}
