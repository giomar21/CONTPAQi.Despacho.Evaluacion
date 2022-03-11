using Evaluacion.Despacho.DATA.Interfaces;
using Evaluacion.Despacho.DATA.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.DATA.Services
{   
    public class PuestoService : IPuestoService
    {
        private readonly IConfiguration _configuration;

        public PuestoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Puesto> Get()
        {
            using (var context = new DespachoContext(_configuration))
            {
                return context.Puestos.ToList();
            }
        }
    }
}
