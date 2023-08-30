using FaycalBlazorShopHRM.Shared.Domain;

namespace FaycalBlazorShopHRM.App.Services;

public interface IJobCategoryDataService
{
    Task<IEnumerable<JobCategory>?> GetAllJobCategories();
    Task<JobCategory?> GetJobCategoryById(int jobCategoryId);
}
