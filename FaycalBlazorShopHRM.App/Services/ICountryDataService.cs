﻿using FaycalBlazorShopHRM.Shared.Domain;

namespace FaycalBlazorShopHRM.App.Services;

public interface ICountryDataService
{
    Task<IEnumerable<Country>?> GetAllCountries();
    Task<Country?> GetCountryById(int countryId);
}
