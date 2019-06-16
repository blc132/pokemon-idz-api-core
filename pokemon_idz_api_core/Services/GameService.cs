using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using pokemon_idz_api_core.Dtos;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Repositories.UnitOfWork;
using pokemon_idz_api_core.Services.Interfaces;

namespace pokemon_idz_api_core.Services
{
    public class GameService: IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public UserPokemon SavePokemon(SavePokemonDto dto)
        {
            if (dto.PokemonId == 0 || dto.UserId == 0)
                return null;
            var user = _unitOfWork.UserRepository.Entities.FirstOrDefault(x => x.Id == dto.UserId);

            if (user is null)
                return null;

            var userPokemon = new UserPokemon()
            {
                PokemonId = dto.PokemonId,
                User = user,
            };

            try
            {
                _unitOfWork.UserPokemonRepository.Add(userPokemon);
            }
            catch (Exception e)
            {
                return null;
            }
            return userPokemon;
        }

        public bool DeletePokemon(DeletePokemonDto dto)
        {
            throw new NotImplementedException();
        }

        public GetUserTeamDto GetUserTeam(int userId)
        {
            throw new NotImplementedException();
        }

        public bool SaveBattleResult(SaveBattleResult dto)
        {
            throw new NotImplementedException();
        }

        public bool SaveMainPokemon(SaveMainPokemonDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
