using Sporganize.Enumerations;
using Sporganize.Models;

namespace Sporganize.DTO.Responses
{
    public class AcceptedUserResponse
    {
        public UserResponse AcceptedUser { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        
        public AcceptedUserResponse(UserAppointment userAppointment) 
        {
            AcceptedUser = new UserResponse(userAppointment.AcceptedUser);
            AppointmentStatus = userAppointment.Status;
        }

    }

}
