using Sporganize.Models;

namespace Sporganize.DTO.Responses
{
    public class SportFacilityResponse
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Phone { get; set; }
        public LocationResponse Location { get; set; }
        public UserResponse Owner { get; set; }

        public SportFacilityResponse(SportFacility sportFacility) 
        {
            Id = sportFacility.Id;
            Name = sportFacility.Name;
            Phone = sportFacility.Phone;
            Location = new LocationResponse(sportFacility.Street);
            Owner = new UserResponse(sportFacility.Owner);
        }

    }

}
