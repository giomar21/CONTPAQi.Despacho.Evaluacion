using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private DateTime _fechaNacimiento;

        public EmpleadoModel()
        {
            this._genero = new GeneroModel();
            this._estadoCivil = new EstadoCivilModel();
            this._puesto = new PuestoModel();

            this._listGenero = new List<GeneroModel>();
            this._listEstadoCivil = new List<EstadoCivilModel>();
            this._listPuesto = new List<PuestoModel>();
            this._fechaNacimiento = DateTime.Now.AddYears(-18);
        }

        public Guid IdEmpleado { get; set; }

        [Required(ErrorMessage = "Nombre es requerido.")]
        [StringLength(100, ErrorMessage = "La longitud del nombre no puede ser más de 100.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "ApellidoPaterno es requerido.")]
        [StringLength(100, ErrorMessage = "La longitud del apellido paterno no puede ser más de 100.")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "ApellidoMaterno es requerido.")]
        [StringLength(100, ErrorMessage = "La longitud del apellido materno no puede ser más de 100.")]
        public string ApellidoMaterno { get; set; }

        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "FechaNacimiento es requerido.")]
        public DateTime FechaNacimiento
        {
            get
            {
                return this._fechaNacimiento;
            }
            set
            {
                this._fechaNacimiento = value;
            }
        }

        [Required (ErrorMessage = "RFC es requerido.")]
        [StringLength(13, ErrorMessage = "La longitud del rfc no puede ser más de 13.")]
        public string Rfc { get; set; }

        [Required(ErrorMessage = "Dirección es requerido.")]
        [StringLength(200, ErrorMessage = "La longitud de la dirección no puede ser más de 200.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Email es requerido.")]
        [StringLength(100, ErrorMessage = "La longitud del email no puede ser más de 100.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Teléfono es requerido.")]
        [StringLength(20, ErrorMessage = "La longitud del teléfono no puede ser más de 20.")]
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
