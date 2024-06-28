using HomeWork.Data;
using HomeWork.Models;
using HomeWork.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Services
{
    public class CityService : ICityService
    {
        private readonly AppDbContext _context;
        public CityService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(City existCity,City city)
        {
            existCity.Name = city.Name;
            await _context.SaveChangesAsync();
        }

        public async Task<List<City>> GetAll()
        {
            return await _context.Cities.Include(m=>m.Country).ToListAsync();
        }

        public async Task<City> GetById(int id)
        {
            return await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);   
        }
    }
}
