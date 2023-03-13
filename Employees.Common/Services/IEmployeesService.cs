using Employees.Common.Models.API;
using Employees.Common.Models.Requests;
using Employees.Common.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Common.Services
{
    public interface IEmployeesService
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> CreateEmployee(EmployeeRequest newEmployeeDetails);

        public Task<Employee> UpdateEmployee(int id, EmployeeRequest updatedEmployee);

        public Task<Employee> GetEmployeeById(int id);

        public Task<Employee> DeleteEmployee(int id);
        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);

        public Task SendOffersToAll(List<string> message);
    }
}
