using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon_idz_api_core.Dtos;
using pokemon_idz_api_core.Models;

namespace pokemon_idz_api_core.Services.Interfaces
{
    public interface IUserService
    {
        User FindUserByEmail(string email);
        User SaveUser(RegisterDto dto);
        User Login(LoginDto dto);
        List<User> GetAll();
        User GetById(int userId);
    }
}
