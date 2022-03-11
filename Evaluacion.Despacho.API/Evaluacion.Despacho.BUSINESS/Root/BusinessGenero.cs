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
    public class BusinessGenero : IBusinessGenero
    {
        private readonly IGeneroService _generoService;

        public BusinessGenero(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        public OperationResult<List<Genero>> Get()
        {
            var result = new OperationResult<List<Genero>>();

            try
            {
                var rItems = _generoService.Get();
                result.Data = rItems;
                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                // Normalmente se manda un error genérico, pero se deja así por fines de que es una evaluación
                return result.ToError($"Error al obtener el listado de géneros: {ex.Message}");
            }
        }
    }
}
