using Sporganize.Enumerations;

namespace Sporganize.DTO.Requests
{
    public class UserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string BornDate { get; set; }
        public int StreetId { get; set; }
        public IFormFile Profile { get; set; } 

    }

}
