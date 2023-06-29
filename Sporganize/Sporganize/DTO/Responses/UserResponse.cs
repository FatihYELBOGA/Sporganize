using Sporganize.Enumerations;
using Sporganize.Models;

namespace Sporganize.DTO.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public FileResponse Profile { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public string? Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public DateTime BornDate { get; set; }
        public LocationResponse Location { get; set; }

        public UserResponse(User user)
        {
            Id = user.Id;

            if(user.Profile != null)
            {
                Profile = new FileResponse(user.Profile);
            }

            Username = user.Username;
            Role = user.Role;
            Phone = user.Phone;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Gender = user.Gender;
            BornDate = user.BornDate;

            if (user.Street != null)
            {
                Location = new LocationResponse(user.Street);
            }

        }

    }

}
