using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Extensions
{
    public static class EnumDescriptor
    {
        /// <summary>
        /// Devuelve el atributo descripción de un enumerador
        /// </summary>
        /// <param name="value">Elemento de un Enumerador</param>
        /// <returns>string</returns>
        public static string GetDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
