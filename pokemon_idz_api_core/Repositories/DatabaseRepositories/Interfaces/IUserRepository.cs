using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Repositories.GenericRepository;

namespace pokemon_idz_api_core.Repositories.DatabaseRepositories.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        User GetByEmail(string email);
        User GetByLogin(string login);
    }
}
