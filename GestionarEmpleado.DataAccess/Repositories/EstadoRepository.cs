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
    public class EstadoRepository : GenericRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(ApplicationContext context) : base(context)
        {
        }

        private IQueryable<EstadoDto> Get()
        {
            var estados = _context.Estados.Select(estados => new EstadoDto
            {
                Id = estados.Id,
                Nombre = estados.Nombre
            });

            return estados; 
        }

        public IQueryable<EstadoDto> GetEstado(int id)
        {
            return Get().Where(e => e.Id == id);
        }

        public IQueryable<EstadoDto> GetEstados()
        {
            return Get();
        }
    }
}
