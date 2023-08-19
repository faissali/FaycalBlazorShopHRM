using FaycalBlazorShopHRM.Shared.Domain;

namespace FaycalBlazorShopHRM.Api.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
