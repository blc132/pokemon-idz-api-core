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
    public class GameService : IGameService
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
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                return null;
            }
            return userPokemon;
        }

        public bool DeletePokemon(DeletePokemonDto dto)
        {
            if (dto.PokemonId == 0 || dto.UserId == 0)
                return false;

            var user = _unitOfWork.UserRepository.Entities.FirstOrDefault(x => x.Id == dto.UserId);

            if (user is null)
                return false;

            var userPokemon = _unitOfWork.UserPokemonRepository.Entities.FirstOrDefault(x => x.PokemonId == dto.PokemonId);

            try
            {
                _unitOfWork.UserPokemonRepository.Remove(userPokemon);

                if (userPokemon != null && user.MainPokemonId == userPokemon.PokemonId)
                {
                    user.MainPokemonId = 0;
                    _unitOfWork.Commit();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public GetUserTeamDto GetUserTeam(int userId)
        {
            var user = _unitOfWork.UserRepository.Get(userId);
            if (user == null)
                return null;
            List<int> pokemonIds = _unitOfWork.UserPokemonRepository.GetByUserId(userId);
            GetUserTeamDto dto = new GetUserTeamDto(user.Login, pokemonIds, user.MainPokemonId);
            return dto;
        }

        public bool SaveBattleResult(SaveBattleResult dto)
        {
            User user = _unitOfWork.UserRepository.Get(dto.UserId);

            if (user == null)
                return false;

            if (dto.Won)
                user.Wins++;
            else
                user.Loses++;

            try
            {
                _unitOfWork.Commit();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool SaveMainPokemon(SaveMainPokemonDto dto)
        {
            User user = _unitOfWork.UserRepository.Get(dto.UserId);

            if (user == null)
                return false;

            user.MainPokemonId = dto.MainPokemonId;

            try
            {
                _unitOfWork.Commit();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
