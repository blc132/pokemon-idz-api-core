using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon_idz_api_core.Models;
using pokemon_idz_api_core.Repositories.GenericRepository;

namespace pokemon_idz_api_core.Repositories.DatabaseRepositories.Interfaces
{
    public interface IBattleRepository: IRepository<Battle>
    {
    }
}
