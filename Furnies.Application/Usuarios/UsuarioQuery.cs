using Furnies.Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Application.Usuarios
{
    public class UsuarioQuery : QueryObject<Usuario>
    {
        public UsuarioQuery IdIgual(Guid id) {
            And(x => x.Id == id);
            return this;
        }

        public UsuarioQuery EmailContiene(string email)
        {
            And(x => x.Email.ToLower().Contains(email));
            return this;
        }

    }
}
