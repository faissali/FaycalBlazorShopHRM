using Blazored.LocalStorage;
using FaycalBlazorShopHRM.App.Helpers;
using FaycalBlazorShopHRM.Shared.Domain;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FaycalBlazorShopHRM.App.Services;

public class EmployeeDataService : IEmployeeDataService
{
    private readonly HttpClient _httpClient;
    private ILocalStorageService _localStorageService;


    public EmployeeDataService(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public Task<Employee> AddEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployee(int employeeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Employee>?> GetAllEmployees(bool refreshRequired = true)
    {
        if (!refreshRequired)
        {
            bool employeeExpirationExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.EmployeesListExpirationKey);

            if (employeeExpirationExists)
            {
                DateTime employeeListExpiration = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.EmployeesListExpirationKey);

                if (employeeListExpiration > DateTime.Now)
                {
                    if(await _localStorageService.ContainKeyAsync(LocalStorageConstants.EmployeesListKey))
                    {
                        return await _localStorageService.GetItemAsync<IEnumerable<Employee>>(LocalStorageConstants.EmployeesListKey);
                    }
                }          
            }
        }

        // Otherwise refresh the list locally from the API and set expiration to 1 minute in the future.
        var employees = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
                       await _httpClient.GetStreamAsync($"api/employee"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Store inn local storage.
        await _localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListKey, employees);
        await _localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListExpirationKey, DateTime.Now.AddMinutes(1));
        
        return employees;
    }

    public async Task<Employee?> GetEmployeeDetails(int employeeId)
    {
        return await JsonSerializer.DeserializeAsync<Employee>(
            await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public Task UpdateEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }
}
