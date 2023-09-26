using EmpleadosApi.Infrasctructure;
using EmpleadosApi.Models;
using EmpleadosDomain.Entities;
using Newtonsoft.Json.Linq;

namespace EmpleadosApi.Services
{
    public class EmployeesServiceApplication : IEmployeeServiceApplication
    {
        private EmployeesDbContext _context; 
        public EmployeesServiceApplication(EmployeesDbContext contextEmpleado)
        {
            _context = contextEmpleado;
        }
       
        public async Task<Guid> DeleteEmployee(Guid idEmployee)
        {
            var employee = _context.Employee.FirstOrDefault(x => x.Id == idEmployee);
            if (employee == null)
            {
                throw new ArgumentException("No existe el empleado.");
            }
            _context.Remove(employee);
            await _context.SaveChangesAsync();
            return idEmployee;
            
        }

        public async Task<EmployeeModel> GetEmployee(Guid idEmployee)
        {
            var employee = _context.Employee.FirstOrDefault(x => x.Id == idEmployee);
            if(employee == null)
            {
              throw new ArgumentException("No existe el empleado.");
            }

            EmployeeModel response = new EmployeeModel()
            {
                IdEmpleado = employee.Id,
                name = employee.Name,
                lastName = employee.LastName,
                secondLastname = employee.SecondLastname,
                sexo = employee.Sexo,
                rol = employee.Rol,
                CreatedAt = DateTime.Now
            };
            return response;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            var employees = _context.Employee.Select(employee => new EmployeeModel{ IdEmpleado = employee.Id,name = employee.Name, lastName = employee.LastName,secondLastname = employee.SecondLastname, sexo = employee.Sexo, rol = employee.Rol, CreatedAt = employee.DateCreated });
            return employees;   
        }

     
        public async Task<EmployeeModel> SaveEmployee(EmployeeModel model)
        {
            Employee employee;

            var id = Guid.NewGuid(); 

            employee = Employee.Crear(id, model.name, model.lastName, model.secondLastname, model.sexo, model.rol, DateTime.Now);


            EmployeeModel response = new EmployeeModel()
            {
                IdEmpleado = id,
                name = model.name, 
                secondLastname = model.secondLastname,
                lastName = model.lastName, 
                sexo = model.sexo, 
                rol = model.rol, 
                CreatedAt = DateTime.Now,
            };

            _context.Add(employee);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<bool> UpdateEmployee(Guid idEmployee,EmployeeModel model)
        {
            var employee = _context.Employee.FirstOrDefault(x => x.Id == idEmployee);
            if (employee == null)
            {
                throw new ArgumentException("No existe el empleado.");
            }

           
            employee.Name = model.name; 
            employee.LastName = model.lastName;
            employee.SecondLastname = model.secondLastname;
            employee.Sexo = model.sexo;
            employee.Rol = model.rol;

            _context.Update(employee);
            await _context.SaveChangesAsync();

 
            return true; 
        }
    }
}
