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
    public class EstadoCivilService : IEstadoCivilService
    {
        private readonly IConfiguration _configuration;

        public EstadoCivilService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<EstadoCivilModel>> Get()
        {
            try
            {
                string urlBase = _configuration["URL_API"];
                string urlConsulta = $"{urlBase}/EstadoCivil";
                var rRquest = await RestClientHelper.JsonRequest<List<EstadoCivilModel>, string>(null, urlConsulta, ContentType.JSON, HTTPMethods.Get);
                return rRquest;
            }
            catch
            {
                return new List<EstadoCivilModel>();
            }
        }
    }
}
