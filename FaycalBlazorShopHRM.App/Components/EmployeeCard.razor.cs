﻿using FaycalBlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace FaycalBlazorShopHRM.App.Components;

public partial class EmployeeCard
{
    [Parameter]
    public Employee Employee { get; set; } = default!;

    [Parameter]
    public EventCallback<Employee> EmployeeQuickViewClicked { get; set; }

    protected override void OnInitialized()
    {
        if(string.IsNullOrEmpty(Employee.LastName))
        {
            throw new Exception("Last name is required");
        }
    }


    //[Inject]
    //public NavigationManager NavigationManager { get; set; } = default!;

    //public void NavigateToDetails(Employee employee)
    //{
    //    // code here ...
    //    NavigationManager.NavigateTo($"/employeedetail/{employee.EmployeeId}");
    //}
}
