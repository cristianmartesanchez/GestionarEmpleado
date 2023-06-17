using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionarEmpleado.Domain.Entities
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public byte[] Fotografia { get; set; }
        [Required(ErrorMessage ="El Campo Nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Apellido es obligatorio.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El Campo Puesto es obligatorio.")]
        public int PuestoId { get; set; }
        [Required(ErrorMessage = "El Campo Fecha Nacimiento es obligatorio.")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El Campo Fecha Contratacion es obligatorio.")]
        public DateTime FechaContratacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int EstadoId
        {
            get; set;
        }

        public Puesto Puesto { get; set; }
        public Estado Estado { get; set; }

    }
}
