using Evaluacion.Despacho.FRONT.Common.Constants;
using Evaluacion.Despacho.FRONT.Models.Communication;
using Evaluacion.Despacho.FRONT.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Models.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IConfiguration _configuration;

        public EmpleadoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResponseEmpleadoModel> Get(EmpleadoFiltro filtro)
        {
            try
            {
                string urlBase = _configuration["URL_API"];
                string urlConsulta = $"{urlBase}/Empleado?NumPagina={filtro.NumPagina}&NumRegistros={filtro.NumRegistros}&Nombre={filtro.Nombre}&RFC={filtro.RFC}&Estatus={filtro.Estatus}";
                var rRquest = await RestClientHelper.JsonRequest<ResponseEmpleadoModel, string>(null, urlConsulta, ContentType.JSON, HTTPMethods.Get);
                return rRquest;
            }
            catch
            {
                return new ResponseEmpleadoModel();
            }
           
        }

        public async Task Create(EmpleadoModel empleado)
        {

            try
            {
                string urlBase = _configuration["URL_API"];
                string urlConsulta = $"{urlBase}/Empleado";
                var rRquest = await RestClientHelper.JsonRequest<object, EmpleadoModel>(empleado, urlConsulta, ContentType.JSON, HTTPMethods.Post);
            }
            catch
            {
                
            }
        }
    }
}
