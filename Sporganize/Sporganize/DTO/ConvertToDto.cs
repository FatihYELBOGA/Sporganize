using Sporganize.DTO.Responses;
using Sporganize.Models;

namespace Sporganize.DTO
{
    public static class ConvertToDto
    {
        public static UserResponse ToUserResponse(User user)
        {
            if(user != null)
            {
                FileResponse profile = null;
                if (user.Profile != null)
                {
                    profile = new FileResponse()
                    {
                        Id = user.Profile.Id,
                        Name = user.Profile.Name,
                        Extension = user.Profile.Extension,
                        Type = user.Profile.Type,
                        Content = user.Profile.Content,
                    };
                }

                return new UserResponse()
                {
                    Id = user.Id,
                    Profile = profile,
                    Username = user.Username,
                    Role = user.Role,
                    Email = user.Email,
                    Phone = user.Phone,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    Gender = user.Gender
                };
            }

            return null;
        }

        public static LocationResponse ToLocationResponse(Street street)
        {
            return new LocationResponse()
            {
                Id = street.Id,
                Street = street.Name,
                District = street.District.Name,
                Province = street.District.Province.Name
            };
        }

        public static TeamResponse ToTeamResponse(Team team)
        {
            FileResponse logo = null;
            if(team.Logo != null)
            {
                logo = new FileResponse()
                {
                    Id = team.Logo.Id,
                    Name = team.Logo.Name,
                    Extension = team.Logo.Extension,
                    Type = team.Logo.Type,
                    Content = team.Logo.Content,
                };
            }

            List<UserResponse> players = new List<UserResponse>();
            foreach (var user in team.Users)
            {
                players.Add(ToUserResponse(user.User));
            }

            return new TeamResponse()
            {
                Id = team.Id,
                Name = team.Name,
                Logo = logo,
                Branch = team.Branch,
                Captain = ToUserResponse(team.Captain),
                Location = ToLocationResponse(team.Street),
                Players = players
            };
        }

    }
}
