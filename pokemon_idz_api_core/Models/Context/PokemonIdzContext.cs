using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pokemon_idz_api_core.Models.Context
{
    public class PokemonIdzContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<UserPokemon> UsersPokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=PokemonIdz;Integrated Security=True");
        }
    }
}
