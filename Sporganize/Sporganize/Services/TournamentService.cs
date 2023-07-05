using Sporganize.DTO;
using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Models;
using Sporganize.Repositories;

namespace Sporganize.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        public TournamentService(ITournamentRepository tournamentRepository) { 
            _tournamentRepository = tournamentRepository;
        }

        public List<TournamentResponse> GetAllTournaments()
        {
            List<TournamentResponse> tournaments = new List<TournamentResponse>();
            foreach(var t in _tournamentRepository.GetAll())
            {
                tournaments.Add(new TournamentResponse(t));
            }

            return tournaments;
        }

        public TournamentResponse GetTournamentById(int id)
        {
            return new TournamentResponse(_tournamentRepository.GetById(id));
        }

        public List<TeamResponse> GetTeamsById(int id)
        {
            List<TeamResponse> teamResponses = new List<TeamResponse>();
            foreach (var t in _tournamentRepository.GetTeamsById(id).Teams)
            {
                teamResponses.Add(new TeamResponse(t.Team));
            }

            return teamResponses;
        }

        public List<LeagueResponse> GetLeagueById(int id)
        {
            List<LeagueResponse> leagueResponses = new List<LeagueResponse>();
            foreach (var l in _tournamentRepository.GetLeagueById(id))
            {
                leagueResponses.Add(new LeagueResponse(l));
            }

            return leagueResponses;
        }

        public TournamentResponse Add(TournamentRequest request)
        {
            string[] startDate = request.StartingDate.Split('-');
            string[] endDate = request.EndingDate.Split('-');

            Tournament tournament = new Tournament()
            {
                Name = request.Name,
                Title = request.Title,
                Description = request.Description,
                StartingDate = new DateTime((int)Int64.Parse(startDate[0]), (int)Int64.Parse(startDate[1]), (int)Int64.Parse(startDate[2])),
                EndingDate = new DateTime((int)Int64.Parse(endDate[0]), (int)Int64.Parse(endDate[1]), (int)Int64.Parse(endDate[2])),
                Branch = request.Branch,
                SportFacilityId = request.SportFacilityId
            };
            int id = _tournamentRepository.Add(tournament).Id;

            return new TournamentResponse(_tournamentRepository.GetById(id));
        }

        public List<LeagueResponse> AddMatch(MatchResultRequest request)
        {
            string[] date = request.Date.Split('-');
            Match match = new Match()
            {
                TeamAId = request.TeamAId,
                TeamBId = request.TeamBId,
                MatchTime = new DateTime((int)Int64.Parse(date[0]), (int)Int64.Parse(date[1]), (int)Int64.Parse(date[2]), (int)Int64.Parse(date[3]), (int)Int64.Parse(date[4]), (int)Int64.Parse(date[5])),
                Result = request.result,
                TournamentId = request.TournamentId
            };

            TeamTournament teamA = _tournamentRepository.GetDataContext().teamTournaments.Where(tt => tt.TeamId == request.TeamAId).FirstOrDefault(); 
            TeamTournament teamB = _tournamentRepository.GetDataContext().teamTournaments.Where(tt => tt.TeamId == request.TeamBId).FirstOrDefault();

            string[] score = request.result.Split('-');
            if (Int64.Parse(score[0]) > Int64.Parse(score[1])){
                teamA.Points = teamA.Points + 3;
                teamA.NumberOfWins = teamA.NumberOfWins + 1;
                teamB.NumberOfLoss = teamB.NumberOfLoss + 1;
            }
            else if (Int64.Parse(score[0]) == Int64.Parse(score[1])){
                teamA.Points = teamA.Points + 1;
                teamA.NumberOfDraws = teamA.NumberOfDraws + 1;
                teamB.Points = teamB.Points + 1;
                teamB.NumberOfDraws = teamB.NumberOfDraws + 1;
            } else {
                teamB.Points = teamB.Points + 3;
                teamB.NumberOfWins = teamB.NumberOfWins + 1;
                teamA.NumberOfLoss = teamA.NumberOfLoss + 1;
            }

            teamA.GoalScored = teamA.GoalScored + (int)Int64.Parse(score[0]);
            teamA.GoalConceded = teamA.GoalConceded + (int)Int64.Parse(score[1]);
            teamB.GoalScored = teamB.GoalScored + (int)Int64.Parse(score[1]);
            teamB.GoalConceded = teamB.GoalConceded + (int)Int64.Parse(score[0]);

            _tournamentRepository.GetDataContext().matches.Add(match);
            _tournamentRepository.GetDataContext().teamTournaments.Update(teamA);
            _tournamentRepository.GetDataContext().teamTournaments.Update(teamB);
            _tournamentRepository.GetDataContext().SaveChanges();

            List<LeagueResponse> leagueResponses = new List<LeagueResponse>();
            foreach (var l in _tournamentRepository.GetLeagueById(request.TournamentId))
            {
                leagueResponses.Add(new LeagueResponse(l));
            }

            return leagueResponses;
        }

        public List<LeagueResponse> AddTeam(JoiningTournamentRequest request)
        {
            TeamTournament teamTournament = new TeamTournament();
            teamTournament.TeamId = request.TeamId;
            teamTournament.TournamentId = request.TournamentId;
            teamTournament.Points = 0;
            teamTournament.NumberOfWins = 0;
            teamTournament.NumberOfDraws = 0;
            teamTournament.NumberOfLoss = 0;
            teamTournament.GoalScored = 0;
            teamTournament.GoalScored = 0;

            _tournamentRepository.GetDataContext().teamTournaments.Add(teamTournament);
            _tournamentRepository.GetDataContext().SaveChanges();

            List<LeagueResponse> leagueResponses = new List<LeagueResponse>();
            foreach (var l in _tournamentRepository.GetLeagueById(request.TournamentId))
            {
                leagueResponses.Add(new LeagueResponse(l));
            }

            return leagueResponses;
        }

    }

}
