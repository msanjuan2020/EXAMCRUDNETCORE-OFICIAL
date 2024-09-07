using System;
using System.Collections.Generic;

namespace EXAMCRUDNETCORE.Models
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int? IdCargo { get; set; }

        public virtual Cargo? oCargo { get; set; }
    }
}
