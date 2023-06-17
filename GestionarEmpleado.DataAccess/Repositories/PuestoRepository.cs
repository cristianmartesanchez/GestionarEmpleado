using GestionarEmpleado.Domain.Entities;
using GestionarEmpleado.Domain.EntitiesDto;
using GestionarEmpleado.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionarEmpleado.DataAccess.Repositories
{
    public class PuestoRepository : GenericRepository<Puesto>, IPuestoRepository
    {
        public PuestoRepository(ApplicationContext context) : base(context)
        {
        }

        private IQueryable<PuestoDto> Get()
        {
            var puesto = _context.Puestos.Select(puestos => new PuestoDto
            {
                Id = puestos.Id,
                Nombre = puestos.Nombre

            });

            return puesto;
        }

        public IQueryable<PuestoDto> GetPuesto(int id)
        {
            var puesto = Get().Where(x => x.Id == id);

            return puesto;
        }
        
        public IQueryable<PuestoDto> GetPuestos()
        {
            var puesto = Get();
            return puesto;
        }
    }
}
