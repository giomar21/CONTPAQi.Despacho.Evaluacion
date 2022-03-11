using System;
using System.Collections.Generic;

#nullable disable

namespace Evaluacion.Despacho.DATA.Model
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Empleados = new HashSet<Empleado>();
        }

        public Guid IdEstadoCivil { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
