using Sporganize.Models;

namespace Sporganize.DTO.Responses
{
    public class LocationResponse
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string Province { get; set; }

        public LocationResponse(Street street)
        {
            Id = street.Id;
            Street = street.Name;
            District = street.District.Name;
            Province = street.District.Province.Name;
        }

    }

}
