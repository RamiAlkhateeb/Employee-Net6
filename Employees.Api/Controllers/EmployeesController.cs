using AutoMapper;
using Employees.Common.Models.Requests;
using Employees.Common.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _employeeRepository;
        private IMapper _mapper;

        public EmployeesController(IEmployeesRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var users = await _employeeRepository.GetAllEmployees();
            return Ok(users);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeRequest employeeRequest)
        {
            var employee =await _employeeRepository.CreateEmployee(employeeRequest);
            return Ok(employee);
        }

        // GET: api/Employees/id
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var foundEmployee = await _employeeRepository.GetEmployeeById(id);
            
            return Ok(foundEmployee);
        }

        // PUT: api/Employees/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeRequest employeeRequest)
        {
            var employee = await _employeeRepository.UpdateEmployee(id, employeeRequest);
            
            return Ok(employee);
        }

        // DELETE: api/Employees/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.DeleteEmployee(id);
            
            return Ok(employee);
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(AuthenticateRequest model)
        {
            var response =  _employeeRepository.Authenticate(model).Result;

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
