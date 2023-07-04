using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Models;
using Sporganize.Repositories;
using Sporganize.Enumerations;

namespace Sporganize.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public TeamResponse Add(TeamRequest request)
        {
            Team team = new Team()
            {
                Name = request.Name,
                Branch = request.Branch,
                StreetId = request.StreetId,
                CaptainId = request.CaptainId
            };

            Models.File logo = null;
            if (request.Logo != null)
            {
                if (request.Logo.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        request.Logo.CopyTo(stream);
                        var bytes = stream.ToArray();
                        logo = new Models.File()
                        {
                            Name = request.Logo.FileName,
                            Type = request.Logo.ContentType,
                            Content = bytes
                        };
                    }
                }
            }
            team.Logo = logo;

            int id = _teamRepository.Add(team).Id;
            return new TeamResponse(_teamRepository.GetById(id));
        }

        public bool InvitePlayer(İnvitationRequest request)
        {
            try
            {
                UserTeams userTeam = new UserTeams();
                userTeam.UserId = request.PlayerId;
                userTeam.TeamId = request.TeamId;
                userTeam.Status = AppointmentStatus.WAITING;

                _teamRepository.GetById(request.TeamId).Users.Add(userTeam);
                _teamRepository.GetDataContext().SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateStatus(InvitationUpdateRequest request)
        {
            try
            {
                UserTeams userTeam = _teamRepository.GetDataContext().userTeams.Where(ut => ut.Id == request.Id).FirstOrDefault();
                userTeam.Status = request.Status;
                _teamRepository.GetDataContext().SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }

}
