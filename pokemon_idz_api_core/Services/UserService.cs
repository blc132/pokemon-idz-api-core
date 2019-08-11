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
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public User FindUserByEmail(string email)
        {
            return _unitOfWork.UserRepository.GetByEmail(email);
        }

        public User SaveUser(RegisterDto dto)
        {
            var userExists = (_unitOfWork.UserRepository.GetByEmail(dto.Email) != null || _unitOfWork.UserRepository.GetByLogin(dto.Login) != null);

            if (userExists)
                return null;

            User user = _mapper.Map<RegisterDto, User>(dto);
            user.Password = HashPassword(user.Password);
            user.DateOfTheLastDraw = DateTime.Today;

            try
            {
                _unitOfWork.UserRepository.Add(user);
                _unitOfWork.Commit();
            }
            catch
            {
                return null;
            }

            return user;
        }

        public User Login(LoginDto dto)
        {
            User user = _unitOfWork.UserRepository.GetByLogin(dto.Login);
            if (user == null)
                return null;
            string hashedPassword = HashPassword(dto.Password);

            if (user.Password == hashedPassword)
                return user;
            return null;
        }

        public List<User> GetAll()
        {
            return _unitOfWork.UserRepository.GetAll().ToList();
        }

        public User GetById(int userId)
        {
            return _unitOfWork.UserRepository.Get(userId);
        }

        private string HashPassword(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
