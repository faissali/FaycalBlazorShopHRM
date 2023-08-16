using BethanysPieShopHRM.Shared.Domain;
using FaycalBlazorShopHRM.App.Models;
using Microsoft.AspNetCore.Components;

namespace FaycalBlazorShopHRM.App.Pages;

public partial class EmployeeDetail
{
    [Parameter]
    public string EmployeeId { get; set; } = string.Empty;

    public Employee? Employee { get; set; }

    protected override Task OnInitializedAsync()
    {
        Employee = MockDataService.Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));

        return base.OnInitializedAsync();
    }
}
