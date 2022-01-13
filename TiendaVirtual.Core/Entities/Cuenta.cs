﻿using System;
using System.Collections.Generic;

namespace TiendaVirtual.Core.Entities
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int CuentaId { get; set; }
        public decimal Monto { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
