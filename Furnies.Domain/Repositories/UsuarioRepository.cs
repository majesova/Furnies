using Furnies.Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Repositories
{

    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(FurniesContext context) : base(context)
        {

        }
    }

}
