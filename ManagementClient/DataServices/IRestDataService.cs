using ManagementClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementClient.DataServices
{
    public interface IRestDataService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployee(Employee employee);

        Task<Employee> GetEmployeeById(int id);

        Task<List<JobRole>> GetAllJobRolesAsync();
    }
}
