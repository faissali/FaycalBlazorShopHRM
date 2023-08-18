using FaycalBlazorShopHRM.Shared.Domain;
using FaycalBlazorShopHRM.App.Models;

namespace FaycalBlazorShopHRM.App.Pages;

public partial class EmployeeOverview
{
    public List<Employee> Employees { get; set; } = default!;
    private Employee? _selectedEmployee;

    private string Title = "Employee Overview";
    protected override void OnInitialized()
    {
        Employees = MockDataService.Employees;
    }

    public void ShowQuickViewEmployee(Employee selectedEmployee)
    {
        _selectedEmployee = selectedEmployee;
    }
}
