using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionarEmpleado.Domain.Entities
{
    public class Puesto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
