using AutoMapper;
using Furnies.Domain.Configuracion;
using Furnies.Domain.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Furnies.WebUI.Models.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductoViewModel, Producto>().ReverseMap();
            CreateMap<ConfiguracionSistemaViewModel, ConfiguracionSistema>().ReverseMap();
        }
    }
}