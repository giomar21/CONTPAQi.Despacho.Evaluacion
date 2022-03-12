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
    public class GeneroService : IGeneroService
    {
        private readonly IConfiguration _configuration;

        public GeneroService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<GeneroModel>> Get()
        {
            try
            {
                string urlBase = _configuration["URL_API"];
                string urlConsulta = $"{urlBase}/Genero";
                var rRquest = await RestClientHelper.JsonRequest<List<GeneroModel>, string>(null, urlConsulta, ContentType.JSON, HTTPMethods.Get);
                return rRquest;
            }
            catch
            {
                return new List<GeneroModel>();
            }
        }
    }
}
