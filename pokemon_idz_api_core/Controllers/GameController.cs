using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokemon_idz_api_core.Dtos;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Services.Interfaces;

namespace pokemon_idz_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        [Route("savePokemon")]
        public IActionResult SavePokemon([FromBody] SavePokemonDto dto)
        {
            UserPokemon userPokemon = _gameService.SavePokemon(dto);

            if (userPokemon == null)
                return BadRequest();
            return Ok(userPokemon);
        }

        [HttpDelete]
        [Route("deletePokemon")]
        public IActionResult DeletePokemon([FromBody] DeletePokemonDto dto)
        {
            bool result = _gameService.DeletePokemon(dto);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpGet]
        [Route("getUserTeam/{userId}")]
        public IActionResult GetUserTeam(int userId)
        {
            GetUserTeamDto userTeam = _gameService.GetUserTeam(userId);
            if (userTeam == null)
                return BadRequest();
            return Ok(userTeam);
        }

        [HttpPost]
        [Route("saveMainPokemon")]
        public IActionResult GetUserTeam([FromBody] SaveMainPokemonDto dto)
        {
            bool result = _gameService.SaveMainPokemon(dto);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPost]
        [Route("battle")]
        public IActionResult SaveBattleResult([FromBody] SaveBattleResult dto)
        {
            bool result = _gameService.SaveBattleResult(dto);
            if (!result)
                return BadRequest();
            return Ok();
        }
    }
}