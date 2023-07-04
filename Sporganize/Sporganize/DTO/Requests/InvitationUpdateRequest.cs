using Sporganize.Enumerations;

namespace Sporganize.DTO.Requests
{
    public class InvitationUpdateRequest
    {
        public int Id { get; set; }
        public AppointmentStatus Status { get; set; }

    }

}
