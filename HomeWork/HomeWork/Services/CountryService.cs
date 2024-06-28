using HomeWork.Data;
using HomeWork.Models;
using HomeWork.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Services
{
    public class CountryService : ICountryService
    {
        private readonly AppDbContext _context;
        public CountryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Country country)
        {
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();  
        }

        public async Task Edit(Country existCountry, Country country)
        {
            existCountry.Name = country.Name;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Country>> GetAll()
        {
            return await _context.Countries.Include(m=>m.Cities).ToListAsync();
        }

        public async Task<Country> GetById(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
