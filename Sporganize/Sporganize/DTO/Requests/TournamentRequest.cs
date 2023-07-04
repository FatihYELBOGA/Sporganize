using Sporganize.Enumerations;

namespace Sporganize.DTO.Requests
{
    public class TournamentRequest
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartingDate { get; set; }
        public string EndingDate { get; set; }
        public Branch Branch { get; set; }
        public int SportFacilityId { get; set; }

    }

}
