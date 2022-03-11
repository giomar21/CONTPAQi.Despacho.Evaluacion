using Evaluacion.Despacho.COMMON;
using Evaluacion.Despacho.COMMON.DTO;
using Evaluacion.Despacho.DATA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.BUSINESS.Interfaces
{
    public interface IBusinessEmpleado
    {
        public OperationResult<ResponseEmpleadoModel> Get(EmpleadoFiltro filtro);
        public OperationResult Create(EmpleadoModel empleado);
        public OperationResult Update(EmpleadoModel empleado);
        public OperationResult Delete(Guid idEmpleado);
    }
}
