using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon_idz_api_core.Dtos;
using pokemon_idz_api_core.Models;

namespace pokemon_idz_api_core.Services.Interfaces
{
    public interface IGameService
    {
        UserPokemon SavePokemon(SavePokemonDto dto);
        bool DeletePokemon(DeletePokemonDto dto);
        GetUserTeamDto GetUserTeam(int userId);
        bool SaveBattleResult(SaveBattleResult dto);
        bool SaveMainPokemon(SaveMainPokemonDto dto);
    }
}
