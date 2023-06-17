using GestionarEmpleado.Domain.Entities;
using GestionarEmpleado.Domain.EntitiesDto;
using GestionarEmpleado.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionarEmpleado.DataAccess.Repositories
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        private readonly ApplicationContext _context;
        public EmpleadoRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<EmpleadoDto> GetEmpleado(int Id)
        {
            var empleado = _context.Empleados
                            .Include(a => a.Estado)
                            .Include(a => a.Puesto)
                            .Where(a => a.Id == Id)
                            .Select(empleado => new EmpleadoDto
                            {
                                Id = empleado.Id,
                                Nombre = empleado.Nombre,
                                Apellido = empleado.Apellido,
                                EstadoId = empleado.EstadoId,
                                PuestoId = empleado.PuestoId,
                                Telefono = empleado.Telefono,
                                FechaNacimiento = empleado.FechaNacimiento,
                                FechaContratacion = empleado.FechaContratacion,
                                CorreoElectronico = empleado.CorreoElectronico,
                                Direccion = empleado.Direccion,
                                Fotografia = empleado.Fotografia,
                                Estado = new EstadoDto
                                {
                                    Id = empleado.Estado.Id,
                                    Nombre = empleado.Estado.Nombre
                                },
                                Puesto = new PuestoDto
                                {
                                    Id = empleado.Puesto.Id,
                                    Nombre = empleado.Puesto.Nombre
                                }
                            });

            return empleado;
        }

        public IQueryable<EmpleadoDto> GetEmpleados()
        {
            var empleados =  _context.Empleados
                .Include(a => a.Estado)
                .Include(a => a.Puesto)
                .Select(empleado => new EmpleadoDto
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                EstadoId = empleado.EstadoId,
                PuestoId = empleado.PuestoId,
                Telefono = empleado.Telefono,
                FechaNacimiento = empleado.FechaNacimiento,
                FechaContratacion = empleado.FechaContratacion,
                CorreoElectronico = empleado.CorreoElectronico,
                Direccion = empleado.Direccion,
                Fotografia = empleado.Fotografia,
                Estado = new EstadoDto
                {
                    Id = empleado.Estado.Id,
                    Nombre = empleado.Estado.Nombre
                },
                Puesto = new PuestoDto
                {
                    Id = empleado.Puesto.Id,
                    Nombre = empleado.Puesto.Nombre
                }
            });

            return empleados;
        }
    }
}
