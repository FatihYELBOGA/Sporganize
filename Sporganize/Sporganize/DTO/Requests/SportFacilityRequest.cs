using System.Globalization;

namespace Sporganize.DTO.Requests
{
    public class SportFacilityRequest
    {
        public string Name { get; set; }
        public IFormFile Profile { get; set; }
        public string Phone { get; set; }
        public int StreetId { get; set; }
        public int OwnerId { get; set; }

    }

}
