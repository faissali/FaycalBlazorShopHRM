using FaycalBlazorShopHRM.App.Services;
using FaycalBlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace FaycalBlazorShopHRM.App.Pages;

public partial class EmployeeEdit
{
    public Employee? Employee { get; set; } = new();
    public List<Country>? Countries { get; set; } = new();
    public List<JobCategory>? JobCategories { get; set; } = new();


    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }

    [Inject]
    public ICountryDataService? CountryDataService { get; set; }

    [Inject]
    public IJobCategoryDataService? JobCategoryDataService { get; set; }

    [Parameter]
    public string? EmployeeId { get; set; }

    protected async override Task OnInitializedAsync()
    {
        this.Countries = (await this.CountryDataService?.GetAllCountries()!)?.ToList();
        this.JobCategories = (await this.JobCategoryDataService?.GetAllJobCategories()!)?.ToList();

        int.TryParse(this.EmployeeId, out var employeeId);

        if(employeeId != 0)
        {
            this.Employee = await this.EmployeeDataService?.GetEmployeeDetails(employeeId)!;
        }
        else
        {
            this.Employee = new Employee()
            {
                CountryId = 1,
                JobCategoryId = 1,
                BirthDate = DateTime.Now,
                JoinedDate = DateTime.Now
            };
        }

    }
}
