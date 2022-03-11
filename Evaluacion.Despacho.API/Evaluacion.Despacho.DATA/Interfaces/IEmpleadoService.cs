using Evaluacion.Despacho.COMMON;
using Evaluacion.Despacho.COMMON.DTO;
using Evaluacion.Despacho.DATA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.DATA.Interfaces
{
    public interface IEmpleadoService
    {
        ResponseEmpleadoModel Get(EmpleadoFiltro filtro);

        void Create(Empleado empleado);

        void Update(Empleado empleado);

        List<Empleado> Get(Guid id);
    }
}
