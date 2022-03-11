using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Models
{
    public class ResponseEmpleadoModel
    {
        private List<EmpleadoModel> _empleados;

        public ResponseEmpleadoModel()
        {
            this._empleados = new List<EmpleadoModel>();
        }

        public List<EmpleadoModel> Empleados
        {
            get
            {
                return this._empleados;
            }
            set
            {
                this._empleados = value;
            }
        }

        public int TotalRegistros { get; set; }
    }
}
