using FaycalBlazorShopHRM.Shared.Domain;
using FaycalBlazorShopHRM.App.Models;
using Microsoft.AspNetCore.Components;
using FaycalBlazorShopHRM.App.Services;

namespace FaycalBlazorShopHRM.App.Pages;

public partial class EmployeeDetail
{
    [Inject]
    private IEmployeeDataService? EmployeeDataService { get; set; }

    [Parameter]
    public string EmployeeId { get; set; } = string.Empty;

    public Employee? Employee { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Employee = await EmployeeDataService!.GetEmployeeDetails(int.Parse(EmployeeId));
    }
}
