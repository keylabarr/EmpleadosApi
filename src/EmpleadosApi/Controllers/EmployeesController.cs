using EmpleadosApi.Models;
using EmpleadosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServiceApplication _service;

        public EmployeesController(IEmployeeServiceApplication service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel model)
        {
            try
            {
                var response = await _service.SaveEmployee(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al guardar el empleado.", ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var response = await _service.GetEmployees();
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al obtener el empleado.", ex);
            }

        }

        [HttpGet("employee/{id:Guid}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            try
            {
                var response = await _service.GetEmployee(id);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al obtener el empleado.", ex);
            }

        }
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, EmployeeModel model)
        {
            try
            {
                var response = _service.UpdateEmployee(id, model).Result;

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al actualizar el empleado.", ex);
            }
        }


        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try 
            { 
                var response = _service.DeleteEmployee(id).Result;
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al eliminar el empleado.", ex);
            }
        }
    }
}
