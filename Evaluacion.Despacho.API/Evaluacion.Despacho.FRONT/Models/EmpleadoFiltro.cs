using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Models
{
    public class EmpleadoFiltro
    {
        private bool _estatus;

        public EmpleadoFiltro()
        {
            this._estatus = true;
        }


        /// <summary>
        /// Cantidad de registros a obtener
        /// </summary>
        public int NumRegistros { get { return 10; } }

        /// <summary>
        /// Página a consultar
        /// </summary>
        public int NumPagina { get; set; }

        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// RFC
        /// </summary>
        public string RFC { get; set; }

        /// <summary>
        /// True = Empleado labora actualmente, False = Empleado dado de baja
        /// </summary>
        public bool Estatus
        {
            get
            {
                return this._estatus;
            }
            set
            {
                this._estatus = value;
            }
        }
    }
}
