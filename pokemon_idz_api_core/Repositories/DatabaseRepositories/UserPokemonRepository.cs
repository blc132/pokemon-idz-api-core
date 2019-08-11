using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Models.Context;
using pokemon_idz_api_core.Repositories.DatabaseRepositories.Interfaces;
using pokemon_idz_api_core.Repositories.GenericRepository;

namespace pokemon_idz_api_core.Repositories.DatabaseRepositories
{
    public class UserPokemonRepository: GenericRepository<UserPokemon>, IUserPokemonRepository
    {
        public UserPokemonRepository(PokemonIdzContext dbContext) : base(dbContext)
        {
        }
    }
}
