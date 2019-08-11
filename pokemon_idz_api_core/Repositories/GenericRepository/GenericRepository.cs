using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pokemon_idz_api_core.Models.Context;

namespace pokemon_idz_api_core.Repositories.GenericRepository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly PokemonIdzContext _dbContext;
        private DbSet<T> DbSet => _dbContext.Set<T>();
        public IQueryable<T> Entities => DbSet;

        public GenericRepository(PokemonIdzContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            DbSet.Attach(entity);
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }
    }
}
