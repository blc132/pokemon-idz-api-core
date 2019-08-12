using System.Collections.Generic;

namespace pokemon_idz_api_core.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
    }
}