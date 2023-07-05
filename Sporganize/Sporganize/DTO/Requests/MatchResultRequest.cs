namespace Sporganize.DTO.Requests
{
    public class MatchResultRequest
    {
        public int TeamAId { get; set; }
        public int TeamBId { get; set; }
        public string Date { get; set; }
        public string result { get; set; }
        public int TournamentId { get; set; }

    }

}
