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
        protected readonly PokemonIdzContext DbContext;
        private DbSet<T> DbSet => DbContext.Set<T>();
        public IQueryable<T> Entities => DbSet;

        public GenericRepository(PokemonIdzContext dbContext)
        {
            DbContext = dbContext;
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
            DbContext.Entry(entity).State = EntityState.Modified;
            DbSet.Attach(entity);
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public T Get(int id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }
    }
}
