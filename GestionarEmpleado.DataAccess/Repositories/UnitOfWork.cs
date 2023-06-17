using GestionarEmpleado.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionarEmpleado.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Empleados = new EmpleadoRepository(_context);
            Puestos = new PuestoRepository(_context);
            Estados = new EstadoRepository(_context);
        }

        public IEmpleadoRepository Empleados { get; private set; }

        public IPuestoRepository Puestos { get; private set; }

        public IEstadoRepository Estados { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
