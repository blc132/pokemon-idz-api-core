using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon_idz_api_core.Dtos;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Services.Interfaces;

namespace pokemon_idz_api_core.Services
{
    public class UserService: IUserService
    {
        public User FindUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User SaveUser(RegisterDto dto)
        {
            throw new NotImplementedException();
        }

        public User Login(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
