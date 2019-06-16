using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokemon_idz_api_core.Models
{
    public class User
    { 
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public DateTime DateOfTheLastDraw { get; set; }
        public bool IsDeleted { get; set; }
        public string Password { get; set; }
        public int MainPokemonId { get; set; }
    }
}
