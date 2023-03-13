using AutoMapper;
using Employees.Common.Models.Requests;
using Employees.Common.Repositories;
using Employees.Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private IMapper _mapper;

        public EmployeesController(IEmployeesService employeesService,
            IMapper mapper)
        {
            _employeesService = employeesService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var users = await _employeesService.GetAllEmployees();
            return Ok(users);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeRequest employeeRequest)
        {
            var employee =await _employeesService.CreateEmployee(employeeRequest);
            return Ok(employee);
        }

        // GET: api/Employees/id
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var foundEmployee = await _employeesService.GetEmployeeById(id);
            
            return Ok(foundEmployee);
        }

        // PUT: api/Employees/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeRequest employeeRequest)
        {
            var employee = await _employeesService.UpdateEmployee(id, employeeRequest);
            
            return Ok(employee);
        }

        // DELETE: api/Employees/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeesService.DeleteEmployee(id);
            
            return Ok(employee);
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = _employeesService.Authenticate(model).Result;

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("productoffers")]
        public async Task<ActionResult> GetOffers()
        {
            List<string> offers = new List<string>();
            offers.Add("20% Off on IPhone 12");
            offers.Add("15% Off on HP Pavillion");
            offers.Add("25% Off on Samsung Smart TV");
            await _employeesService.SendOffersToAll(offers);
            return Ok("Offers sent successfully to all users!");
        }
    }
}
