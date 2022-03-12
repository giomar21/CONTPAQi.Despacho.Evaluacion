using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Models
{
    public class ResponseEmpleadoModel
    {
        private List<EmpleadoModel> _empleados;
        private EmpleadoModel _model;

        public ResponseEmpleadoModel()
        {
            this._empleados = new List<EmpleadoModel>();
            this._model = new EmpleadoModel();
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

        public int PaginaActual { get; set; }

        public int TotalPaginas { get; set; }

        public EmpleadoModel Empleado
        {
            get
            {
                return this._model;
            }
            set
            {
                this._model = value;
            }
        }
    }
}
