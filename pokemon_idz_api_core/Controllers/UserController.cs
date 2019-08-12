using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokemon_idz_api_core.Dtos;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Services.Interfaces;

namespace pokemon_idz_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            User user = _userService.SaveUser(dto);

            if (user == null)
                return BadRequest();
            return Ok(new {user.Login, user.Id});
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            User user = _userService.Login(dto);

            if (user == null)
                return BadRequest();
            return Ok(new {user.Login, user.Id});
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            IList<GetUserDto> users = _userService.GetAll();
            return Ok(users);
        }


        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetById(int userId)
        {
            User user = _userService.GetById(userId);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

    }
}