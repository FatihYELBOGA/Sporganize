using Sporganize.Enumerations;
using Sporganize.Models;

namespace Sporganize.DTO.Responses
{
    public class AppointmentResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostTime { get; set; }
        public UserResponse User { get; set; }
        public Branch Branch { get; set; }
        public LocationResponse Location { get; set; }
        public List<UserResponse> AcceptedUsers { get; set; }

        public AppointmentResponse(Appointment appointment)
        {
            Id = appointment.Id;
            Title = appointment.Title;
            Description = appointment.Description;
            PostTime = appointment.PostTime;

            if(appointment.User != null)
            {
                User = new UserResponse(appointment.User);
            }

            Branch = appointment.Branch;
            Location = new LocationResponse(appointment.Street);

            if(appointment.Users != null)
            {
                List<UserResponse> acceptedUsers = new List<UserResponse>();
                foreach (var u in appointment.Users)
                {
                    acceptedUsers.Add(new UserResponse(u.AcceptedUser));
                }

                AcceptedUsers = acceptedUsers;
            }
        }

    }

}
