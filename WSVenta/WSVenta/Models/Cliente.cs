﻿using System;
using System.Collections.Generic;

namespace WSVenta.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
