using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using GestionarEmpleado.Domain.Entities;
using GestionarEmpleado.Domain.EntitiesDto;
using GestionarEmpleado.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionarEmpleado.Web.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmpleadosController( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<DataTablesJsonResult> list(IDataTablesRequest request)
        {
         
            var empleados = await _unitOfWork.Empleados.GetEmpleados().ToListAsync();

            if (!string.IsNullOrEmpty(request.Search.Value))
            {
                empleados = empleados.Where(c => c.Nombre.Contains(request.Search.Value) ||
                                        c.Apellido.Contains(request.Search.Value)).ToList();
            }

            var filteredData = empleados.Skip(request.Start).Take(request.Length).ToList();

            var response = DataTablesResponse.Create(request, filteredData.Count(), empleados.Count(),filteredData);

            return new DataTablesJsonResult(response,true);

        }


        // GET: EmpleadosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var empleado = await _unitOfWork.Empleados.GetEmpleado(id).FirstOrDefaultAsync();
            await Select();
            return View(empleado);
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            ViewBag.Puestos = _unitOfWork.Puestos.GetPuestos().ToList();
            return View();
        }

        private async Task<byte[]> CargarImagen(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();

                    return imageBytes;
                }
            }

            return null;
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormFile Fotografia, EmpleadoDto empleado)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(empleado);
                }

                empleado.Fotografia = await CargarImagen(Fotografia);
                empleado.EstadoId = 1;

                var newEmpleado = _mapper.Map<Empleado>(empleado);
                
                _unitOfWork.Empleados.Add(newEmpleado);
                _unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(empleado);
            }
        }

        private async Task Select()
        {
            ViewBag.Puestos = await _unitOfWork.Puestos.GetPuestos().ToListAsync();
            ViewBag.Estados = await _unitOfWork.Estados.GetEstados().ToListAsync();
        }

        // GET: EmpleadosController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var empleado = await _unitOfWork.Empleados.GetEmpleado(id).FirstOrDefaultAsync();
            await Select();
            return View(empleado);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormFile newFotografia, EmpleadoDto editempleado)
        {
            await Select();
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(editempleado);
                }

                var empleado =  _unitOfWork.Empleados.GetById(id);

                if (empleado == null)
                {
                    return View(editempleado);
                }

                var newImage = await CargarImagen(newFotografia);

                if (newImage != null && newImage != empleado.Fotografia)
                {
                    empleado.Fotografia = newImage;
                }

                empleado.Nombre = editempleado.Nombre;
                empleado.Apellido = editempleado.Apellido;
                empleado.Telefono = editempleado.Telefono;
                empleado.PuestoId = editempleado.PuestoId;
                empleado.CorreoElectronico = editempleado.CorreoElectronico;
                empleado.FechaContratacion = empleado.FechaContratacion;
                empleado.FechaNacimiento = editempleado.FechaNacimiento;
                empleado.Direccion = editempleado?.Direccion;
                empleado.EstadoId = editempleado.EstadoId;
   
                _unitOfWork.Empleados.Update(empleado);
                _unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(editempleado);
            }
        }

    }
}
