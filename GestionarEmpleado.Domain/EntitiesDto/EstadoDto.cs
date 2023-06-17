using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionarEmpleado.Domain.EntitiesDto
{
    public class EstadoDto
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<EmpleadoDto> Empleados { get; set; }
    }
}
