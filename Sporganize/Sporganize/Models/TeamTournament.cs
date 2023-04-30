namespace Sporganize.Models
{
    public class TeamTournament
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public int? TournamentId { get; set; }
        public Tournament? Tournament { get; set; }
        public int Points { get; set; }

    }

}
