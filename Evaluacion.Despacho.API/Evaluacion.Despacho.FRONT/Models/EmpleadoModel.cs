using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Models
{
    public class EmpleadoModel
    {
        private GeneroModel _genero;
        private EstadoCivilModel _estadoCivil;
        private PuestoModel _puesto;
        private IEnumerable<GeneroModel> _listGenero;
        private IEnumerable<EstadoCivilModel> _listEstadoCivil;
        private IEnumerable<PuestoModel> _listPuesto;

        public EmpleadoModel()
        {
            this._genero = new GeneroModel();
            this._estadoCivil = new EstadoCivilModel();
            this._puesto = new PuestoModel();

            this._listGenero = new List<GeneroModel>();
            this._listEstadoCivil = new List<EstadoCivilModel>();
            this._listPuesto = new List<PuestoModel>();
        }

        public Guid IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public GeneroModel Genero
        {
            get
            {
                return this._genero;
            }
            set
            {
                this._genero = value;
            }
        }
        public EstadoCivilModel EstadoCivil
        {
            get
            {
                return this._estadoCivil;
            }
            set
            {
                this._estadoCivil = value;
            }
        }
        public PuestoModel Puesto
        {
            get
            {
                return this._puesto;
            }
            set
            {
                this._puesto = value;
            }
        }
        public IEnumerable<GeneroModel> ListGenero 
        {
            get 
            {
                return this._listGenero; 
            }
            set 
            { 
                this._listGenero = value; 
            }
        }
        public IEnumerable<EstadoCivilModel> ListEstadoCivil
        {
            get
            {
                return this._listEstadoCivil;
            }
            set
            {
                this._listEstadoCivil = value;
            }
        }
        public IEnumerable<PuestoModel> ListPuesto
        {
            get
            {
                return this._listPuesto;
            }
            set
            {
                this._listPuesto = value;
            }
        }
    }
}
