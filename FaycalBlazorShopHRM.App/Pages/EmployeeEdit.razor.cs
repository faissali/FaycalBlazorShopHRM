using FaycalBlazorShopHRM.App.Services;
using FaycalBlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FaycalBlazorShopHRM.App.Pages;

public partial class EmployeeEdit
{
    public Employee? Employee { get; set; } = new();
    public List<Country>? Countries { get; set; } = new();
    public List<JobCategory>? JobCategories { get; set; } = new();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;
    private IBrowserFile? selectedFile;

    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }

    [Inject]
    public ICountryDataService? CountryDataService { get; set; }

    [Inject]
    public IJobCategoryDataService? JobCategoryDataService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;


    [Parameter]
    public string? EmployeeId { get; set; }

    protected async Task HandleValidSubmit()
    {
        Saved = false;

        if (this.Employee!.EmployeeId != 0)
        {
            await EmployeeDataService?.UpdateEmployee(this.Employee)!;
            this.Saved = true;
            this.Message = "Employee updated";
            this.StatusClass = "alert-success";
        }
        else
        {
            if (selectedFile != null)
            {
                var file = selectedFile;

                Stream stream = file.OpenReadStream();
                MemoryStream ms = new();
                await stream.CopyToAsync(ms);
                stream.Close();

                Employee.ImageName = file.Name;
                Employee.ImageContent = ms.ToArray();
            }

            var addedEmployee = await EmployeeDataService?.AddEmployee(this.Employee)!;

            if (addedEmployee != null)
            {
                this.Saved = true;
                this.Message = "New employee added";
                this.StatusClass = "alert-success";
            }
            else
            {
                this.Saved = false;
                this.Message = "Something went wrong adding the new employee. Please try again.";
                this.StatusClass = "alert-danger";
            }
        }
    }

    protected void HandleInvalidSubmit()
    {
        this.Saved = false;
        this.Message = "There are some validation errors. Please try again.";
        this.StatusClass = "alert-danger";
    }

    protected async Task DeleteEmployee()
    {
        await this.EmployeeDataService?.DeleteEmployee(Employee!.EmployeeId)!;
        this.Saved = true;
        this.Message = "Employee deleted";
        this.StatusClass = "alert-success";
    }

    protected async override Task OnInitializedAsync()
    {
        this.Countries = (await this.CountryDataService?.GetAllCountries()!)?.ToList();
        this.JobCategories = (await this.JobCategoryDataService?.GetAllJobCategories()!)?.ToList();

        int.TryParse(this.EmployeeId, out var employeeId);

        if (employeeId != 0)
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

    protected async Task OnInputFileChange(InputFileChangeEventArgs e)
    {
        selectedFile = e.File;
        StateHasChanged();
    }

    public void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/employeeoverview");
    }
}
