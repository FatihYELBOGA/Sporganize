using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Models;
using Sporganize.Repositories;

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
            team.Logo = logo;

            int id = _teamRepository.Add(team).Id;
            return new TeamResponse(_teamRepository.GetById(id));
        }

    }

}
