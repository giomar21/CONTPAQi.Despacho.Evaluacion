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
    public class GeneroController : ControllerBase
    {
        private readonly IBusinessGenero _businessGenero;

        public GeneroController(IBusinessGenero businessGenero)
        {
            _businessGenero = businessGenero;
        }

        [HttpGet]
        public ActionResult<List<Genero>> Get()
        {
            var result = _businessGenero.Get();

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }
    }
}
