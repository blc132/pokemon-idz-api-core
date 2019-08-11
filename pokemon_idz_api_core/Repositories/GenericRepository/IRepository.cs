using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokemon_idz_api_core.Repositories.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        void Remove(T entity);
        void Add(T entity);
        void Update(T entity);
        Task AddAsync(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
