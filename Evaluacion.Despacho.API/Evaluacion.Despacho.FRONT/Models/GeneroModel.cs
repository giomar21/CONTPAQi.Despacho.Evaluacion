using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Models
{
    public class GeneroModel
    {
        [Required]
        public Guid IdGenero { get; set; }
        public string Descripcion { get; set; }

    }
}
