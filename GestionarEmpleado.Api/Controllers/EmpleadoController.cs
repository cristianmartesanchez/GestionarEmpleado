using AutoMapper;
using GestionarEmpleado.Domain.EntitiesDto;
using GestionarEmpleado.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionarEmpleado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmpleadoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<EmpleadoController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var empleado = await _unitOfWork.Empleados.GetEmpleados().ToListAsync();
            return Ok(empleado);
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var empleado = await _unitOfWork.Empleados.GetEmpleado(id).FirstOrDefaultAsync();
            return Ok(empleado);
        }


        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, string Telefono, string Correo)
        {
            var empleado = _unitOfWork.Empleados.GetById(id);

            if (empleado == null)
            {
                return NotFound();
            }

            empleado.CorreoElectronico = Correo;
            empleado.Telefono = Telefono;
            _unitOfWork.Empleados.Update(empleado);
            _unitOfWork.Commit();
            return Ok();
        }


    }
}
