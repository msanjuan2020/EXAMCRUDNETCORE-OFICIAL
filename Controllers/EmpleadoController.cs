using EXAMCRUDNETCORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXAMCRUDNETCORE.Controllers
{
    public class EmpleadoController : Controller
    {

        private readonly DBCRUDCOREContext _DBContext;

        public EmpleadoController(DBCRUDCOREContext context)
        {
            _DBContext = context;
        }
        public IActionResult Index()
        {
            //List<Empleado> empleados = _DBContext.Empleados.Include(cargo => cargo.oCargo).ToList();
            return View();
        }
        // Método que devuelve la lista de empleados en formato JSON
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var empleados = await _DBContext.Empleados
                .Select(e => new
                {
                    e.IdEmpleado,
                    e.Nombres,
                    e.Apellidos,
                    e.Correo,
                    e.Telefono,
                    CargoDescripcion = e.oCargo.Descripcion
                }).ToListAsync();

            return Json(empleados);
        }
        [HttpGet]
        public async Task<IActionResult> Obtener(int id)
        {
            var empleado = await _DBContext.Empleados.FindAsync(id);
            return Json(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Empleado empleado)
        {
            if (empleado.IdEmpleado == 0)
            {
                _DBContext.Empleados.Add(empleado);  // Nuevo empleado
            }
            else
            {
                _DBContext.Empleados.Update(empleado);  // Actualizar empleado
            }
            await _DBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var empleado = await _DBContext.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _DBContext.Empleados.Remove(empleado);
                await _DBContext.SaveChangesAsync();
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerCargos()
        {
            var cargos = await _DBContext.Cargos.Select(c => new {
                c.IdCargo,
                c.Descripcion
            }).ToListAsync();

            return Json(cargos);
        }
        // hola mundo


    }
}
