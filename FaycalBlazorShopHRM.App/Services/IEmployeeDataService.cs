using FaycalBlazorShopHRM.Shared.Domain;

namespace FaycalBlazorShopHRM.App.Services;

public interface IEmployeeDataService
{
    Task<IEnumerable<Employee>?> GetAllEmployees(bool refreshRequired = true);
    Task<Employee?> GetEmployeeDetails(int employeeId);
    Task<Employee?> AddEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
}
