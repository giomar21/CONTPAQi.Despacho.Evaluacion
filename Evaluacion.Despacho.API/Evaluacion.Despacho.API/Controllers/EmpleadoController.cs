
using Evaluacion.Despacho.BUSINESS.Interfaces;
using Evaluacion.Despacho.COMMON.DTO;
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
    public class EmpleadoController : ControllerBase
    {
        private readonly IBusinessEmpleado _businessEmpleado;

        public EmpleadoController(IBusinessEmpleado businessEmpleado)
        {
            _businessEmpleado = businessEmpleado;
        }

        [HttpGet]
        public ActionResult<ResponseEmpleadoModel> Get([FromQuery] EmpleadoFiltro filtro)
        {
            var result = _businessEmpleado.Get(filtro);

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpPost]
        public ActionResult Create([FromBody] EmpleadoModel empleado)
        {
            var result = _businessEmpleado.Create(empleado);

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] EmpleadoModel empleado)
        {
            var result = _businessEmpleado.Update(empleado);

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok();
        }

        [HttpPatch]
        public ActionResult Baja([FromQuery] Guid IdEmpleado)
        {
            var result = _businessEmpleado.Delete(IdEmpleado);

            if (!result.Success) return BadRequest(new { message = result.Message });

            return Ok();
        }
    }
}
