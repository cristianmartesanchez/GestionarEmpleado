using GestionarEmpleado.Domain.Entities;
using GestionarEmpleado.Domain.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionarEmpleado.Domain.Interfaces
{
    public interface IPuestoRepository : IGenericRepository<Puesto>
    {
        IQueryable<PuestoDto> GetPuestos();
        IQueryable<PuestoDto> GetPuesto(int id);
    }
}
