using Furnies.Domain.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Repositories
{

    public class ConfiguracionSistemaRepository : BaseRepository<ConfiguracionSistema>
    {
        public ConfiguracionSistemaRepository(FurniesContext context) : base(context)
        {

        }
    }

}
