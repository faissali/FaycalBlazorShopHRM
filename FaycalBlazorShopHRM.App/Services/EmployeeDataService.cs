﻿using FaycalBlazorShopHRM.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FaycalBlazorShopHRM.App.Services;

public class EmployeeDataService: IEmployeeDataService
{
    private readonly HttpClient _httpClient;

    public EmployeeDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Employee> AddEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployee(int employeeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Employee>?> GetAllEmployees()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
                       await _httpClient.GetStreamAsync($"api/employee"),new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<Employee?> GetEmployeeDetails(int employeeId)
    {
        return await JsonSerializer.DeserializeAsync<Employee>(
            await _httpClient.GetStreamAsync($"api/employee/{employeeId}"),new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public Task UpdateEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }
}
