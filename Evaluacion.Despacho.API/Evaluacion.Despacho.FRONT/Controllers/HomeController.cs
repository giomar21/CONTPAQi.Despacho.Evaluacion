using Evaluacion.Despacho.FRONT.Models;
using Evaluacion.Despacho.FRONT.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmpleadoService _empleadoService;

        public HomeController(ILogger<HomeController> logger, IEmpleadoService empleadoService)
        {
            _logger = logger;
            _empleadoService = empleadoService;
        }

        public async Task<IActionResult> Index(int pagina = 1)
        {
            var filtro = new EmpleadoFiltro() { NumPagina = pagina, Estatus = true };
            var rEmpleados = await _empleadoService.Get(filtro);
            rEmpleados.PaginaActual = pagina;
            rEmpleados.TotalPaginas = GetTotalPagina(rEmpleados.TotalRegistros, filtro.NumRegistros);

            return View(rEmpleados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private int GetTotalPagina(int totalGlobal, int registrosPorPagina)
        {
            decimal paginas = Decimal.Divide(totalGlobal, registrosPorPagina);
            int totalPAginas = (int)Math.Ceiling(paginas);
            return totalPAginas;
        }
    }
}
