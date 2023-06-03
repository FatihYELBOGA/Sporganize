using Sporganize.Enumerations;
using Sporganize.Models;

namespace Sporganize.DTO.Responses
{
    public class TeamResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public FileResponse? Logo { get; set; }
        public Branch Branch { get; set; }
        public UserResponse? Captain { get; set; }
        public LocationResponse? Location { get; set; }
        public List<UserResponse>? Players { get; set; }

        public TeamResponse(Team team) 
        {
            Id = team.Id;
            Name = team.Name;

            if(team.Logo != null)
            {
                Logo = new FileResponse(team.Logo);
            }

            Branch = team.Branch;

            if(team.Captain != null)
            {
                Captain = new UserResponse(team.Captain);
            }

            if(team.Street != null)
            {
                Location = new LocationResponse(team.Street);
            }

            if(team.Users != null)
            {
                List<UserResponse> players = new List<UserResponse>();
                foreach (var p in team.Users)
                {
                    players.Add(new UserResponse(p.User));
                }
                Players = players;
            }
        }

    }

}
