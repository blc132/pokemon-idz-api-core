using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokemon_idz_api_core.Models
{
    public class UserPokemon
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
