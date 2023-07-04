using Sporganize.Enumerations;
using Sporganize.Models;

namespace Sporganize.DTO.Responses
{
    public class TournamentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public Branch Branch { get; set; }
        public SportFacilityResponse SportFacility { get; set; }

        public TournamentResponse(Tournament tournament) 
        {
            Id = tournament.Id;
            Name = tournament.Name;
            Title = tournament.Title;
            Description = tournament.Description;
            StartingDate = tournament.StartingDate;
            EndingDate = tournament.EndingDate;
            Branch = tournament.Branch;

            if (tournament.SportFacility != null)
            {
                SportFacility = new SportFacilityResponse(tournament.SportFacility);
            }
            
        }

    }

}
