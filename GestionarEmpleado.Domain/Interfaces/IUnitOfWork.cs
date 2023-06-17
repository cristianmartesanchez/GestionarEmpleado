using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionarEmpleado.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IEmpleadoRepository Empleados { get; }
        IPuestoRepository Puestos { get; }  
        IEstadoRepository Estados { get; }
        int Commit();
    }
}
