using HomeWork.Models;

namespace HomeWork.Services.Interfaces
{
    public interface ICountryService
    {
        Task Create(Country country);
        Task Delete(Country country);
        Task Edit(Country existCountry, Country country);
        Task<Country> GetById(int id);
        Task<List<Country>> GetAll();
    }
}
