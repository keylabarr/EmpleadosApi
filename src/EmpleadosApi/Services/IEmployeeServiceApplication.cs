using EmpleadosApi.Models;
using Newtonsoft.Json.Linq;

namespace EmpleadosApi.Services
{
    public interface IEmployeeServiceApplication
    {
        Task<EmployeeModel> SaveEmployee(EmployeeModel model);

        Task<EmployeeModel> GetEmployee(Guid idEmployee);

        Task<IEnumerable<EmployeeModel>> GetEmployees();

        Task<Guid> DeleteEmployee(Guid idEmployee);

        Task<bool> UpdateEmployee(Guid idEmployee,EmployeeModel model);

    }
}
