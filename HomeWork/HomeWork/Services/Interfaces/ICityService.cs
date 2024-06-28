using HomeWork.Models;

namespace HomeWork.Services.Interfaces
{
    public interface ICityService
    {
        Task Create(City city);
        Task Delete(City city);
        Task Edit(City existCity,City city);
        Task<City> GetById(int id);
        Task<List<City>> GetAll();
    }
}
