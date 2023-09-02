using Microsoft.EntityFrameworkCore;
using Sporganize.Configurations;
using Sporganize.DTO.Responses;
using Sporganize.Generics;
using Sporganize.Models;

namespace Sporganize.Repositories
{
    public class TournamentRepository : GenericRepository<Tournament>, ITournamentRepository
    {

        public TournamentRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public override List<Tournament> GetAll()
        {
            return GetDataContext().tournaments.
                Include(t => t.SportFacility).
                    ThenInclude(sf => sf.Owner).
                Include(t => t.SportFacility).
                    ThenInclude(sf => sf.Street).
                        ThenInclude(s => s.District).
                            ThenInclude(d => d.Province).
                ToList();
        }

        public override Tournament GetById(int id)
        {
            return GetDataContext().tournaments.
                Where(t => t.Id == id).
                Include(t => t.SportFacility).
                    ThenInclude(sf => sf.Owner).
                Include(t => t.SportFacility).
                    ThenInclude(sf => sf.Street).
                        ThenInclude(s => s.District).
                            ThenInclude(d => d.Province).
                FirstOrDefault();
        }

        public List<TeamTournament> GetLeagueById(int id)
        {
            return GetDataContext().teamTournaments.
                Where(tt => tt.TournamentId == id).
                Include(tt => tt.Tournament).
                Include(tt => tt.Team).
                ToList();
        }

        public Tournament GetTeamsById(int id)
        {
            return GetDataContext().tournaments.
                Where(t => t.Id == id).
                Include(t => t.Teams).  
                    ThenInclude(tt => tt.Team).
                FirstOrDefault();
        }

    }

}
