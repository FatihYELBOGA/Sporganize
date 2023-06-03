using Sporganize.Models;

namespace Sporganize.DTO.Responses
{
    public class LeagueResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int NumberOfLoss { get; set; }
        public int NumberOfWins { get; set; }
        public int NumberOfDraws { get; set; }
        public int GoalScored { get; set; }
        public int GoalConceded { get; set; }

        public LeagueResponse(TeamTournament teamTournament) 
        {
            Id = teamTournament.Id;
            Name = teamTournament.Team.Name;
            Points = teamTournament.Points;
            NumberOfLoss = teamTournament.NumberOfLoss;
            NumberOfWins = teamTournament.NumberOfWins;
            NumberOfDraws = teamTournament.NumberOfDraws;
            GoalScored = teamTournament.GoalScored;
            GoalConceded = teamTournament.GoalConceded;
        }

    }

}
