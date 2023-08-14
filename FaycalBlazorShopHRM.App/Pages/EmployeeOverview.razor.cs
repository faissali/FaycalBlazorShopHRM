using BethanysPieShopHRM.Shared.Domain;
using FaycalBlazorShopHRM.App.Models;

namespace FaycalBlazorShopHRM.App.Pages;

public partial class EmployeeOverview
{
    public List<Employee> Employees { get; set; } = default!;

    protected override void OnInitialized()
    {
        Employees = MockDataService.Employees;
    }
}
