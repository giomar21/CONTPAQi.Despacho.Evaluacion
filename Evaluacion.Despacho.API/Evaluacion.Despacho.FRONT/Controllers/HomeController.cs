using Evaluacion.Despacho.FRONT.Models;
using Evaluacion.Despacho.FRONT.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmpleadoService _empleadoService;
        private readonly IPuestoService _puestoService;
        private readonly IGeneroService _generoService;
        private readonly IEstadoCivilService _estadoCivilService;

        public HomeController(
            ILogger<HomeController> logger,
            IEmpleadoService empleadoService,
            IPuestoService puestoService,
            IGeneroService generoService,
            IEstadoCivilService estadoCivilService
            )
        {
            _logger = logger;
            _empleadoService = empleadoService;
            _puestoService = puestoService;
            _generoService = generoService;
            _estadoCivilService = estadoCivilService;
        }

        public async Task<IActionResult> Index(int pagina = 1)
        {
            var rEmpleados = new ResponseEmpleadoModel();

            var filtro = new EmpleadoFiltro() { NumPagina = pagina, Estatus = true };

            rEmpleados = await GetEmpleados(filtro);

            return View(rEmpleados);
        }


        public async Task<IActionResult> Crear(EmpleadoModel empleado)
        {
            if (!ModelState.IsValid)
            {
                return View(empleado);
            }
            var filtro = new EmpleadoFiltro() { NumPagina = 1, Estatus = true };

            await _empleadoService.Create(empleado);

            var rEmpleados = await GetEmpleados(filtro);

            return RedirectToAction("Index", rEmpleados);
        }

        public async Task<IActionResult> Editar(EmpleadoModel empleado)
        {
            if (!ModelState.IsValid)
            {
                return View(empleado);
            }
            var filtro = new EmpleadoFiltro() { NumPagina = 1, Estatus = true };

            await _empleadoService.Update(empleado);

            var rEmpleados = await GetEmpleados(filtro);

            return RedirectToAction("Index", rEmpleados);
        }

        public async Task<IActionResult> Delete(EmpleadoModel empleado)
        {
            var filtro = new EmpleadoFiltro() { NumPagina = 1, Estatus = true };

            await _empleadoService.Delete(empleado.IdEmpleado);

            var rEmpleados = await GetEmpleados(filtro);

            return View("Index", rEmpleados);
        }

        public async Task<IActionResult> Refresh()
        {
            var filtro = new EmpleadoFiltro() { NumPagina = 1, Estatus = true };

            var rEmpleados = await GetEmpleados(filtro);

            return View("Index", rEmpleados);
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Search(EmpleadoFiltro filtro)
        {
            filtro.NumPagina = 1;

            var rEmpleados = await GetEmpleados(filtro);

            return View("Index", rEmpleados);
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

        private async Task<ResponseEmpleadoModel> GetEmpleados(EmpleadoFiltro filtro)
        {
            List<PuestoModel> rPuestos = new List<PuestoModel>();
            List<GeneroModel> rGeneros = new List<GeneroModel>();
            List<EstadoCivilModel> rEstodosCiviles = new List<EstadoCivilModel>();
            
            var rEmpleados = await _empleadoService.Get(filtro);
            rEmpleados.PaginaActual = filtro.NumPagina;
            rEmpleados.TotalPaginas = GetTotalPagina(rEmpleados.TotalRegistros, filtro.NumRegistros);

            if(!rPuestos.Any()) rPuestos = await _puestoService.Get();
            if (!rGeneros.Any()) rGeneros = await _generoService.Get();
            if (!rEstodosCiviles.Any()) rEstodosCiviles = await _estadoCivilService.Get();

            rEmpleados.Empleado.ListEstadoCivil = rEstodosCiviles;
            rEmpleados.Empleado.ListGenero = rGeneros;
            rEmpleados.Empleado.ListPuesto = rPuestos;

            return rEmpleados;
        }
    }
}
