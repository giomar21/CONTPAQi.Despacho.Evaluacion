using System;
using System.Collections.Generic;

#nullable disable

namespace Evaluacion.Despacho.DATA.Model
{
    public partial class Empleado
    {
        public Guid IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public Guid IdGenero { get; set; }
        public Guid IdEstadoCivil { get; set; }
        public Guid IdPuesto { get; set; }

        public virtual EstadoCivil IdEstadoCivilNavigation { get; set; }
        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Puesto IdPuestoNavigation { get; set; }
    }
}
