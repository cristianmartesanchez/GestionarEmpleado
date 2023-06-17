using AutoMapper;
using GestionarEmpleado.Domain.Entities;
using GestionarEmpleado.Domain.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionarEmpleado.Domain.Mapper
{
    public  class EmpleadoProfile : Profile
    {
        public EmpleadoProfile() {
            CreateMap<EmpleadoDto, Empleado>();
            CreateMap<Empleado, EmpleadoDto>();
        }

    }
}
