using ManagementClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ManagementClient.DataServices
{
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = "http://52.45.52.255:5000";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No Internet Access...");
                return ;
            }

            try
            {
                string jsonEmployee = JsonSerializer.Serialize<Employee>(employee, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/employee", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully Added Employee...");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx respomse");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }
            return ;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No Internet Access...");
                return;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/employee/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully Deleted Employee...");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx respomse");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }
            return;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            List<Employee> employees = new List<Employee>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No Internet Access...");
                return employees;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/employee");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    employees = JsonSerializer.Deserialize<List<Employee>>(content , _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("--> Non http 2xx Response");
                }
            }
            catch (Exception ex) {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }
            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = new Employee();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No Internet Access...");
                return employee;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/employee/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    employee = JsonSerializer.Deserialize<Employee>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("--> Non http 2xx Response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }
            return employee;
        }

        public async Task<List<JobRole>> GetAllJobRolesAsync()
        {
            List<JobRole> jobRoles = new List<JobRole>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No Internet Access...");
                return jobRoles;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/jobroles");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    jobRoles = JsonSerializer.Deserialize<List<JobRole>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("--> Non http 2xx Response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }
            return jobRoles;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No Internet Access...");
                return;
            }

            try
            {
                string jsonEmployee = JsonSerializer.Serialize<Employee>(employee, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/employee/{employee.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully Added Employee...");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx respomse");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }
            return;
        }
    }
}
