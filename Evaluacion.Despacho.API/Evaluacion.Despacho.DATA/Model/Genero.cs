using System;
using System.Collections.Generic;

#nullable disable

namespace Evaluacion.Despacho.DATA.Model
{
    public partial class Genero
    {
        public Genero()
        {
            Empleados = new HashSet<Empleado>();
        }

        public Guid IdGenero { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
