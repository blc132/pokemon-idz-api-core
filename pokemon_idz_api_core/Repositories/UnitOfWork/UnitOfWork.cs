using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Models.Context;
using pokemon_idz_api_core.Repositories.DatabaseRepositories;
using pokemon_idz_api_core.Repositories.DatabaseRepositories.Interfaces;
using pokemon_idz_api_core.Repositories.GenericRepository;

namespace pokemon_idz_api_core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PokemonIdzContext _dbContext;

        private IUserRepository _userRepository;
        private IUserPokemonRepository _userPokemonRepository;
        private IBattleRepository _battleRepository;

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_dbContext));
        public IUserPokemonRepository UserPokemonRepository => _userPokemonRepository ?? (_userPokemonRepository = new UserPokemonRepository(_dbContext));
        public IBattleRepository BattleRepository => _battleRepository ?? (_battleRepository = new BattleRepository(_dbContext));

        public UnitOfWork(PokemonIdzContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
