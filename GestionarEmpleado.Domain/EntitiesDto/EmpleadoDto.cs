using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GestionarEmpleado.Domain.EntitiesDto
{
    public class EmpleadoDto
    {
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }
        public byte[] Fotografia { get; set; }

        [DataMember]
        [JsonProperty("nombre")]
        [Required(ErrorMessage ="El Campo Nombre es obligatorio.")]
        public string Nombre { get; set; }
        [DataMember]
        [JsonProperty("apellido")]
        [Required(ErrorMessage = "El Campo Apellido es obligatorio.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El Campo Puesto es obligatorio.")]
        [DataMember]
        [JsonProperty("puestoId")]
        public int PuestoId { get; set; }
        [Required(ErrorMessage = "El Campo Fecha Nacimiento es obligatorio.")]
        [DataMember]
        [JsonProperty("fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        [JsonProperty("fechaContratacion")]
        [Required(ErrorMessage = "El Campo Fecha Contratacion es obligatorio.")]
        public DateTime FechaContratacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int EstadoId
        {
            get; set;
        }

        [DataMember]
        [JsonProperty("puesto")]
        public PuestoDto Puesto { get; set; }
        [DataMember]
        [JsonProperty("estado")]
        public EstadoDto Estado { get; set; }

    }
}
