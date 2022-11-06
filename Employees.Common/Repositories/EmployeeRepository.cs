using AutoMapper;
using Employees.Common.Data;
using Employees.Common.Helpers;
using Employees.Common.Models.API;
using Employees.Common.Models.Requests;
using Microsoft.Extensions.Logging;
using BCryptNet = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Employees.Common.Models.Response;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Employees.Common.Repositories
{
    public class EmployeeRepository : IEmployeesRepository
    {
        private readonly EmployeesDbContext _employeesDbContext;
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeesDbContext employeesDbContext, 
            IMapper mapper,
            ILogger<EmployeeRepository> logger,
            IOptions<AppSettings> appSettings)
        {
            _employeesDbContext = employeesDbContext;
            _mapper = mapper;
            _logger = logger;
            _appSettings = appSettings.Value;

        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> allEmployees = null;
            try
            {
                allEmployees= _employeesDbContext.Employees.ToList();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get all employees failed.");
            }
            return allEmployees;
        }

        public async Task<Employee> CreateEmployee(EmployeeRequest newEmployeeDetails)
        {
            
                if (_employeesDbContext.Employees.Any(x => x.Email == newEmployeeDetails.Email))
                    throw new AppException("User with the email '" + newEmployeeDetails.Email + "' already exists");
                // map model to new user object
                var employee = _mapper.Map<Employee>(newEmployeeDetails);
                // hash password
                employee.PasswordHash = BCryptNet.HashPassword(newEmployeeDetails.Password);  

                await _employeesDbContext.AddAsync(employee);
                await _employeesDbContext.SaveChangesAsync();

            
            return employee;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            
                var user = _employeesDbContext.Employees.FirstOrDefault(x => x.Id == id);
                if (user == null) throw new KeyNotFoundException("User not found");
                return user;
            
            
        }

        public async Task<Employee> UpdateEmployee(int id, EmployeeRequest updatedEmployee)
        {
            
                var employee = GetEmployeeById(id).Result;
                // validate
                if (updatedEmployee.Email != employee.Email && _employeesDbContext.Employees.Any(x => x.Email == updatedEmployee.Email))
                    throw new AppException("User with the email '" + updatedEmployee.Email + "' already exists");

                // hash password if it was entered
                if (!string.IsNullOrEmpty(updatedEmployee.Password))
                    employee.PasswordHash = BCryptNet.HashPassword(updatedEmployee.Password);
                _mapper.Map(updatedEmployee, employee);
                _employeesDbContext.Employees.Update(employee);
                _employeesDbContext.SaveChanges();
            
            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            
                var employee = GetEmployeeById(id).Result;
                _employeesDbContext.Employees.Remove(employee);
                _employeesDbContext.SaveChanges();
            
            return employee;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = _employeesDbContext.Employees.FirstOrDefault(x => x.Email == model.UserEmail );

            // return null if user not found
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash)) 
                throw new AppException("Username or password is incorrect");


            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(Employee user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }
}
