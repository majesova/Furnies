using Furnies.Domain;
using Furnies.Domain.Configuracion;
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
        public string GetWelcomeMessage()
        {
            var value = GetValue("WelcomeMessage");
            return value;
        }

        public List<ConfiguracionSistema> GetConfiguraciones() {
            return _confRepository.GetAll().ToList();
        }

        public ConfiguracionSistema GetByKey(string key) {
            var result = _confRepository.Find(key);
            if (result == null)
                throw new Exception($"No se encuentra la clave {key}");
            return result;
        }


        public ConfiguracionSistema Update(string key, string value) {
            var conf = _confRepository.Find(key);
            conf.Valor = value;
            _confRepository.Update(conf);
            _context.SaveChanges();
            return conf;
        }

        private string GetValue(string key) {
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
