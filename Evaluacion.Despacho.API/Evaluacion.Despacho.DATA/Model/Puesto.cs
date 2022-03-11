using System;
using System.Collections.Generic;

#nullable disable

namespace Evaluacion.Despacho.DATA.Model
{
    public partial class Puesto
    {
        public Puesto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public Guid IdPuesto { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
