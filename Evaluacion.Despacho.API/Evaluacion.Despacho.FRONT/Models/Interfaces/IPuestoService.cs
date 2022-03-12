using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Models.Interfaces
{
    public interface IPuestoService
    {
        Task<List<PuestoModel>> Get();
    }
}
