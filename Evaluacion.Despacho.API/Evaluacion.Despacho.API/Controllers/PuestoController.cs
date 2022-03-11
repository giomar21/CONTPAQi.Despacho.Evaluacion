using Evaluacion.Despacho.BUSINESS.Interfaces;
using Evaluacion.Despacho.DATA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private readonly IBusinessPuesto _businessPuesto;

        public PuestoController(IBusinessPuesto businessPuesto)
        {
            _businessPuesto = businessPuesto;
        }

        [HttpGet]
        public ActionResult<List<Puesto>> Get()
        {
            var result = _businessPuesto.Get();

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }

    }
}
