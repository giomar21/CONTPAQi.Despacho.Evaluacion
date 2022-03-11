using Evaluacion.Despacho.DATA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.DATA.Interfaces
{
    public interface IGeneroService
    {
        List<Genero> Get();
    }
}
