using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon_idz_api_core.Models;

namespace pokemon_idz_api_core.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<UserPokemon> UserPokemonRepository { get; }
        IRepository<Battle> BattleRepository { get; }

        void Commit();
        Task CommitAsync();
        void RejectChanges();
        void Dispose();
    }
}
