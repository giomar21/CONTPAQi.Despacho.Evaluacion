using Evaluacion.Despacho.COMMON;
using Evaluacion.Despacho.COMMON.DTO;
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
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IConfiguration _configuration;

        public EmpleadoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Create(Empleado empleado)
        {
            using (var context = new DespachoContext(_configuration))
            {
                empleado.IdEmpleado = Guid.NewGuid();

                context.Add(empleado);

                context.SaveChanges();
            }
        }

        public void Update(Empleado empleado)
        {
            using (var context = new DespachoContext(_configuration))
            {
                var rEmpleado = context.Empleados.Where(x => x.IdEmpleado == empleado.IdEmpleado).ToList().First();

                rEmpleado.Email = empleado.Email;
                rEmpleado.Telefono = empleado.Telefono;
                rEmpleado.IdPuesto = empleado.IdPuesto;
                rEmpleado.FechaBaja = empleado.FechaBaja;
                rEmpleado.IdEstadoCivil = empleado.IdEstadoCivil;
                rEmpleado.Direccion = empleado.Direccion;

                context.SaveChanges();
            }
        }

        public ResponseEmpleadoModel Get(EmpleadoFiltro filtro)
        {
            var result = new ResponseEmpleadoModel();

            using (var context = new DespachoContext(_configuration))
            {
                var query = from empleado in context.Empleados
                            join estadoCivil in context.EstadoCivils on empleado.IdEstadoCivil equals estadoCivil.IdEstadoCivil
                            join puesto in context.Puestos on empleado.IdPuesto equals puesto.IdPuesto
                            join genero in context.Generos on empleado.IdGenero equals genero.IdGenero
                            select new 
                            { 
                                Empleado = empleado, 
                                EstadoCivil = estadoCivil,
                                Puesto = puesto,
                                Genero = genero
                            };

                if (filtro != null)
                {
                    if (!string.IsNullOrWhiteSpace(filtro.Nombre))
                        query = query.Where(s => (s.Empleado.Nombre + " " + s.Empleado.ApellidoPaterno + " " + s.Empleado.ApellidoMaterno).Contains(filtro.Nombre));
                    if (!string.IsNullOrWhiteSpace(filtro.RFC))
                        query = query.Where(s => s.Empleado.Rfc.Contains(filtro.RFC));
                    if (filtro.Estatus)
                        query = query.Where(s => s.Empleado.FechaBaja == null || s.Empleado.FechaBaja > DateTime.Now);
                    if (!filtro.Estatus)
                        query = query.Where(s => s.Empleado.FechaBaja != null && s.Empleado.FechaBaja <= DateTime.Now);
                }

                result.TotalRegistros = query.Count();

                var lEmpleados = query
                    .Skip((filtro.NumPagina - 1) * filtro.NumRegistros)
                    .Take(filtro.NumRegistros)
                    .ToList();

                lEmpleados.ForEach(s => result.Empleados.Add(new EmpleadoModel() { 
                    ApellidoMaterno = s.Empleado.ApellidoMaterno,
                    ApellidoPaterno = s.Empleado.ApellidoPaterno,
                    FechaAlta = s.Empleado.FechaAlta,
                    Direccion = s.Empleado.Direccion,
                    Email = s.Empleado.Email,
                    IdEmpleado = s.Empleado.IdEmpleado,
                    FechaBaja = s.Empleado.FechaBaja,
                    FechaNacimiento = s.Empleado.FechaNacimiento,
                    Nombre = s.Empleado.Nombre,
                    Rfc = s.Empleado.Rfc,
                    Telefono = s.Empleado.Telefono,
                    EstadoCivil = new EstadoCivilModel() 
                    { 
                        IdEstadoCivil = s.EstadoCivil.IdEstadoCivil,
                        Descripcion = s.EstadoCivil.Descripcion
                    },
                    Puesto = new PuestoModel() 
                    {
                        IdPuesto = s.Puesto.IdPuesto,
                        Descripcion = s.Puesto.Descripcion
                    },
                    Genero = new GeneroModel()
                    {
                        IdGenero = s.Genero.IdGenero,
                        Descripcion = s.Genero.Descripcion
                    }
                }));
            }

            return result;
        }

        public List<Empleado> Get(Guid id)
        {
            using (var context = new DespachoContext(_configuration))
            {
                return context.Empleados.Where(s => s.IdEmpleado == id).ToList();
            }
        }
    }
}
