using System.Collections.Generic;

namespace pokemon_idz_api_core.Dtos
{
    public class GetUserTeamDto
    {
        public GetUserTeamDto(string login, List<int> pokemonIds, int mainPokemonId)
        {
            Login = login;
            PokemonIds = pokemonIds;
            MainPokemonId = mainPokemonId;
        }

        public string Login { get; set; }
        public List<int> PokemonIds { get; set; }
        public int MainPokemonId { get; set; }
    }
}