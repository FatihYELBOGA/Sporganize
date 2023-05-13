﻿using Microsoft.AspNetCore.Mvc;
using Sporganize.DTO.Responses;
using Sporganize.Models;
using Sporganize.Services;

namespace Sporganize.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet("/tournaments")]
        public List<TournamentResponse> GetTournament()
        {
            return _tournamentService.GetAllTournaments();
        }

        [HttpGet("/tournaments/{id}")]
        public TournamentResponse GetTournamentById(int id)
        {
            return _tournamentService.GetTournamentById(id);
        }
    }
}
