using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
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

        public List<int> GetByUserId(int userId)
        {
            return DbContext.Set<UserPokemon>().Where(x => x.UserId == userId).Select(x => x.PokemonId).ToList();
        }
    }
}
