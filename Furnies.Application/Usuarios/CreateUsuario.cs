﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Application.Usuarios
{
    public class CreateUsuario
    {
        public string Email { get; set; }   
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public Guid[] RolesIds { get; set; }
    }
}
