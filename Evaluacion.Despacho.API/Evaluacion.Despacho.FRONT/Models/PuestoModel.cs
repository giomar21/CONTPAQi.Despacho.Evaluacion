using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Models
{
    public class PuestoModel
    {
        [Required]
        public Guid IdPuesto { get; set; }
        public string Descripcion { get; set; }
    }
}
