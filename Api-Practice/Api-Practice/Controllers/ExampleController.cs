using Api_Practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult Test()
        //{
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult Delete()
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //public IActionResult Create()
        //{
        //    return Ok();
        //}

        //[HttpPut]
        //public IActionResult Edit()
        //{
        //    return Ok();
        //}


        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    List<string> list = new() { "Semed", "Ilham", "Aqsin" };
        //    return Ok(list);
        //}

        //[HttpGet("{id}")]
        //public IActionResult Search([FromQuery] string name, [FromRoute] int id)
        //{   
        //    return Ok(name + " " + id);
        //}

        //[HttpPost]
        //public IActionResult Create([FromBody] User user)
        //{
        //    return Ok(user.Name + " " + user.Surname);
        //}



    }
}
