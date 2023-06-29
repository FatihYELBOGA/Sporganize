using Sporganize.DTO.Responses;
using Sporganize.Enumerations;

namespace Sporganize.DTO.Requests
{
    public class TeamRequest
    {
        public string Name { get; set; }
        public IFormFile Logo { get; set; }
        public Branch Branch { get; set; }
        public int StreetId { get; set; }
        public int CaptainId { get; set; }

    }

}
