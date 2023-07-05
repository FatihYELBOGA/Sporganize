using Sporganize.Models;

namespace Sporganize.DTO.Responses
{
    public class SportFacilityResponse
    {
        public int Id { get; set; }
        public FileResponse Profile { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public LocationResponse Location { get; set; }
        public UserResponse Owner { get; set; }

        public SportFacilityResponse(SportFacility sportFacility) 
        {
            Id = sportFacility.Id;

            if (sportFacility.Profile != null)
            {
                Profile = new FileResponse(sportFacility.Profile);
            }

            Name = sportFacility.Name;
            Phone = sportFacility.Phone;
            Location = new LocationResponse(sportFacility.Street);
            Owner = new UserResponse(sportFacility.Owner);
        }

    }

}
