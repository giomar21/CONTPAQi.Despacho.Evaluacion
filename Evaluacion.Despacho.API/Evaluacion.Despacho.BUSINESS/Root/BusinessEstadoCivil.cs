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
    public class BusinessEstadoCivil : IBusinessEstadoCivil
    {
        private readonly IEstadoCivilService _estadoCivilService;

        public BusinessEstadoCivil(IEstadoCivilService estadoCivilService)
        {
            _estadoCivilService = estadoCivilService;
        }

        public OperationResult<List<EstadoCivil>> Get()
        {
            var result = new OperationResult<List<EstadoCivil>>();

            try
            {
                var rItems = _estadoCivilService.Get();
                result.Data = rItems;
                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                // Normalmente se manda un error genérico, pero se deja así por fines de que es una evaluación
                return result.ToError($"Error al obtener el listado de estados civiles: {ex.Message}");
            }
        }
    }
}
