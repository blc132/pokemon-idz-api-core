using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokemon_idz_api_core.Dtos
{
    public class RegisterDto
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MatchingPassword { get; set; }
    }
}
