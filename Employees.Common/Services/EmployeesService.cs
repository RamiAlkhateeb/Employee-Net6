using AutoMapper;
using Employees.Common.Hub;
using Employees.Common.Models.API;
using Employees.Common.Models.Requests;
using Employees.Common.Models.Response;
using Employees.Common.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Common.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeeRepository;
        private readonly ILogger<EmployeesRepository> _logger;
        //private readonly AppSettings _appSettings;
        private IHubContext<MessageHub, IMessageHubClient> _messageHub;
        private readonly IMapper _mapper;

        public EmployeesService(IEmployeesRepository employeeRepository, 
            ILogger<EmployeesRepository> logger, 
            IMapper mapper, 
            IHubContext<MessageHub, IMessageHubClient> messageHub)
        {
            _messageHub = messageHub;
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public Task SendOffersToAll(List<string> message)
        {
            return _messageHub.Clients.All.SendOffersToUser(message);
        }
    
        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            return _employeeRepository.Authenticate(model);
        }

        public Task<Employee> CreateEmployee(EmployeeRequest newEmployeeDetails)
        {
            return _employeeRepository.CreateEmployee(newEmployeeDetails);
        }

        public Task<Employee> DeleteEmployee(int id)
        {
           return _employeeRepository.DeleteEmployee(id); 
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public Task<Employee> UpdateEmployee(int id, EmployeeRequest updatedEmployee)
        {
            return _employeeRepository.UpdateEmployee(id, updatedEmployee);
        }
    }
}
