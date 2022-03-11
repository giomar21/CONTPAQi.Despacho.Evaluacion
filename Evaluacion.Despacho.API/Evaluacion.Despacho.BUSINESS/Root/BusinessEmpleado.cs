using Evaluacion.Despacho.BUSINESS.Interfaces;
using Evaluacion.Despacho.COMMON;
using Evaluacion.Despacho.COMMON.DTO;
using Evaluacion.Despacho.DATA.Interfaces;
using Evaluacion.Despacho.DATA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.BUSINESS.Root
{
    public class BusinessEmpleado : IBusinessEmpleado
    {
        private readonly IEmpleadoService _empleadoService;

        public BusinessEmpleado(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        public OperationResult Create(EmpleadoModel empleado)
        {
            var result = new OperationResult();

            try
            {
                Empleado newEmpleado = new Empleado()
                {
                    ApellidoMaterno = empleado.ApellidoMaterno,
                    ApellidoPaterno = empleado.ApellidoPaterno,
                    Direccion = empleado.Direccion,
                    Email = empleado.Email,
                    FechaNacimiento = empleado.FechaNacimiento,
                    Nombre = empleado.Nombre,
                    Rfc = empleado.Rfc,
                    Telefono = empleado.Telefono,
                    FechaAlta = DateTime.Now,
                    IdEstadoCivil = empleado.EstadoCivil.IdEstadoCivil,
                    IdGenero = empleado.Genero.IdGenero,
                    IdPuesto = empleado.Puesto.IdPuesto
                };

                _empleadoService.Create(newEmpleado);

                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                // Normalmente se manda un error genérico, pero se deja así por fines de que es una evaluación
                return result.ToError($"Error al crear el empleado: {ex.Message}");
            }
        }

        public OperationResult Delete(Guid idEmpleado)
        {
            var result = new OperationResult();

            try
            {
                var empleados = _empleadoService.Get(idEmpleado);
                if (!empleados.Any()) return result.ToError($"El empleado a dar de baja no existe. Verifique.");
                empleados.First().FechaBaja = DateTime.Now;

                _empleadoService.Update(empleados.First());

                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                // Normalmente se manda un error genérico, pero se deja así por fines de que es una evaluación
                return result.ToError($"Error al eliminar (dar de baja) el empleado: {ex.Message}");
            }
        }

        public OperationResult<ResponseEmpleadoModel> Get(EmpleadoFiltro filtro)
        {
            var result = new OperationResult<ResponseEmpleadoModel>();

            try
            {
                var rEmpleados = _empleadoService.Get(filtro);
                result.Data = rEmpleados;
                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                // Normalmente se manda un error genérico, pero se deja así por fines de que es una evaluación
                return result.ToError($"Error al obtener el listado de empleados: {ex.Message}");
            }
        }

        public OperationResult Update(EmpleadoModel empleado)
        {
            var result = new OperationResult();

            try
            {
                var empleados = _empleadoService.Get(empleado.IdEmpleado);
                if (!empleados.Any()) return result.ToError($"El empleado a actualizar no existe. Verifique.");

                empleados.First().FechaBaja = empleado.FechaBaja;
                empleados.First().Email = empleado.Email;
                empleados.First().Telefono = empleado.Telefono;
                empleados.First().Direccion = empleado.Direccion;
                empleados.First().IdPuesto = empleado.Puesto.IdPuesto;
                empleados.First().IdEstadoCivil = empleado.EstadoCivil.IdEstadoCivil;

                _empleadoService.Update(empleados.First());

                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                // Normalmente se manda un error genérico, pero se deja así por fines de que es una evaluación
                return result.ToError($"Error al actualizar los datos del empleado: {ex.Message}");
            }
        }
    }
}
