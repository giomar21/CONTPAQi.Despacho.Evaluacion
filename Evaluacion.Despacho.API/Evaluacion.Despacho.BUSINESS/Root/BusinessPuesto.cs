using Evaluacion.Despacho.BUSINESS.Interfaces;
using Evaluacion.Despacho.COMMON;
using Evaluacion.Despacho.DATA.Interfaces;
using Evaluacion.Despacho.DATA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.BUSINESS.Root
{
    public class BusinessPuesto : IBusinessPuesto
    {
        private readonly IPuestoService _puestoService;

        public BusinessPuesto(IPuestoService puestoService)
        {
            _puestoService = puestoService;
        }

        public OperationResult<List<Puesto>> Get()
        {
            var result = new OperationResult<List<Puesto>>();

            try
            {
                var rItems = _puestoService.Get();
                result.Data = rItems;
                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                // Normalmente se manda un error genérico, pero se deja así por fines de que es una evaluación
                return result.ToError($"Error al obtener el listado de puestos: {ex.Message}");
            }
        }
    }
}
