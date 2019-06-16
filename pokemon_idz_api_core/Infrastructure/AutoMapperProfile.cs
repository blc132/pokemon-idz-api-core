using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using pokemon_idz_api_core.Dtos;
using pokemon_idz_api_core.Models;

namespace pokemon_idz_api_core.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<User, LoginDto>();
        }
    }
}
