﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Models.Context;
using pokemon_idz_api_core.Repositories.DatabaseRepositories.Interfaces;
using pokemon_idz_api_core.Repositories.GenericRepository;

namespace pokemon_idz_api_core.Repositories.DatabaseRepositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(PokemonIdzContext dbContext) : base(dbContext)
        {
        }

        public User GetByEmail(string email)
        {
            return DbContext.Set<User>().SingleOrDefault(x => x.Email == email);
        }

        public User GetByLogin(string login)
        {
            return  DbContext.Set<User>().SingleOrDefault(x => x.Login == login);
        }
    }
}
