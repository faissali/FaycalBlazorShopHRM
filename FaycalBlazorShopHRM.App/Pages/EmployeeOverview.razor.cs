using FaycalBlazorShopHRM.Shared.Domain;
using FaycalBlazorShopHRM.App.Models;
using Microsoft.AspNetCore.Components;
using FaycalBlazorShopHRM.App.Services;

namespace FaycalBlazorShopHRM.App.Pages;

public partial class EmployeeOverview
{
    private Employee? _selectedEmployee;

    [Inject]
    private IEmployeeDataService? EmployeeDataService { get; set; }

    public List<Employee>? Employees { get; set; }
    
    private string Title = "Employee Overview";
    protected override async Task OnInitializedAsync()
    {
        Employees = (await EmployeeDataService!.GetAllEmployees())?.ToList();
    }

    public void ShowQuickViewEmployee(Employee selectedEmployee)
    {
        _selectedEmployee = selectedEmployee;
    }
}
