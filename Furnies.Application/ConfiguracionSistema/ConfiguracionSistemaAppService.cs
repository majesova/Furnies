using Furnies.Domain;
using Furnies.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Application
{
    public class ConfiguracionSistemaAppService: IDisposable
    {
        private FurniesContext _context;

        private ConfiguracionSistemaRepository _confRepository;

        public ConfiguracionSistemaAppService(FurniesContext context)
        {
            _context = context;
            _confRepository = new ConfiguracionSistemaRepository(_context);
        }

        public int GetPageSize() {
            var value = GetValue("PageSize");
            return Convert.ToInt32(value);
        }

        public string GetNombreSistema() {
            var value = GetValue("SystemName");
            return value;
        }

        private string GetValue(string key) {
            //          Type type = Type.GetType(result.TipoDato);
            //          var pageSize = Convert.ChangeType(result.Valor,type);
            var result = _confRepository.Find(key);
            if (result == null)
                throw new Exception($"No se encuentra la clave {key}");
            return result.Valor;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
