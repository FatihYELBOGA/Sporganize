using Sporganize.DTO.Responses;
using Sporganize.Enumerations;

namespace Sporganize.DTO.Requests
{
    public class AppointmentRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostTime { get; set; }
        public Branch Branch { get; set; }
        public AppointmentReason AppointmentReason { get; set; }
        public int StreetId { get; set; }
        public int UserId { get; set; }

    }

}
