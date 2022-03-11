using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Models.Interfaces
{
    public interface IEmpleadoService
    {
        Task<ResponseEmpleadoModel> Get(EmpleadoFiltro filtro);
    }
}
