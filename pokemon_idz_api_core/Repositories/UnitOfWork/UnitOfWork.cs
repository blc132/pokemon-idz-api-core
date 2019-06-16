using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Models.Context;
using pokemon_idz_api_core.Repositories.GenericRepository;

namespace pokemon_idz_api_core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PokemonIdzContext _dbContext;

        private IRepository<User> _userRepository;
        private IRepository<UserPokemon> _userPokemonRepository;
        private IRepository<Battle> _battleRepository;

        public IRepository<User> UserRepository => _userRepository ?? (_userRepository = new GenericRepository<User>(_dbContext));
        public IRepository<UserPokemon> UserPokemonRepository => _userPokemonRepository ?? (_userPokemonRepository = new GenericRepository<UserPokemon>(_dbContext));
        public IRepository<Battle> BattleRepository => _battleRepository ?? (_battleRepository = new GenericRepository<Battle>(_dbContext));

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
