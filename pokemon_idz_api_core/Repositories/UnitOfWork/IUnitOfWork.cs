using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Repositories.DatabaseRepositories;
using pokemon_idz_api_core.Repositories.DatabaseRepositories.Interfaces;
using pokemon_idz_api_core.Repositories.GenericRepository;

namespace pokemon_idz_api_core.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserPokemonRepository UserPokemonRepository { get; }
        IBattleRepository BattleRepository { get; }

        void Commit();
        Task CommitAsync();
        void RejectChanges();
        void Dispose();
    }
}
