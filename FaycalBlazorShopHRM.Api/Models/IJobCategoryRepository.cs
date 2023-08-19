using FaycalBlazorShopHRM.Shared.Domain;

namespace FaycalBlazorShopHRM.Api.Models
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}
