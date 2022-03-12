using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Models.Interfaces
{
    public interface IEmpleadoService
    {
        Task<ResponseEmpleadoModel> Get(EmpleadoFiltro filtro);

        Task Create(EmpleadoModel empleado);

        Task Update(EmpleadoModel empleado);

        Task Delete(Guid idEmpleado);
    }
}
