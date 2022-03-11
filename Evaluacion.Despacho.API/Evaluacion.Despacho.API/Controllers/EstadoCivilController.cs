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
    public class EstadoCivilController : ControllerBase
    {
        private readonly IBusinessEstadoCivil _businessEstadoCivil;

        public EstadoCivilController(IBusinessEstadoCivil businessEstadoCivil)
        {
            _businessEstadoCivil = businessEstadoCivil;
        }

        [HttpGet]
        public ActionResult<List<EstadoCivil>> Get()
        {
            var result = _businessEstadoCivil.Get();

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }
    }
}
