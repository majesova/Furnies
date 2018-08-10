using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Furnies.WebUI.Models
{
    public class ConfiguracionSistemaViewModel
    {
        public string Clave { get; set; }
        public string Valor  { get; set; }
        public string TipoDato { get; set; }
        public string NombreMostrar { get; set; }
    }

    public class SaveConfigurationViewModel {
        public string Clave { get; set; }
        public string Valor { get; set; }
    }
}