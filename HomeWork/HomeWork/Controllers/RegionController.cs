using HomeWork.Models;
using HomeWork.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        public RegionController(ICityService cityService,
                                ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] Country country)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            await _countryService.Create(country);
            return CreatedAtAction(nameof(CreateCountry),country);
        }


        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var datas = await _countryService.GetAll();
            return Ok(datas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        {
            var existCountry = await _countryService.GetById(id);
            if (existCountry is null) return NotFound();

            await _countryService.Delete(existCountry);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditCountry([FromQuery]int? id, [FromBody] Country country)
        {
            if(id is null) return BadRequest();
            var existCountry = await _countryService.GetById((int)id);
            if(existCountry is null) return NotFound();

            await _countryService.Edit(existCountry, country);
            return Ok();
        }





        //--------------------------------------------------------------------------------------------------------




        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] City city)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _cityService.Create(city);    
            return CreatedAtAction(nameof(CreateCity),city);
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var datas = await _cityService.GetAll();
            return Ok(datas);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCity([FromQuery]int? id)
        {
            if (id is null) return BadRequest();
            var existCity = await _cityService.GetById((int)id);
            if(existCity is null) return NotFound();

            await _cityService.Delete(existCity);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> EditCity([FromQuery]int? id, [FromBody] City city)
        {
            if(id is null) return BadRequest();
            var existCity = await _cityService.GetById((int) id);
            if(existCity is null) return NotFound();

            await _cityService.Edit(existCity, city);
            
            return Ok();
        }




    }
}
