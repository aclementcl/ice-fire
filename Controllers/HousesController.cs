using houses.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace houses.Controllers;

[Route("api/[controller]")]
public class HousesController : ControllerBase
{
    private readonly IHousesService _service;
    public HousesController(IHousesService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var response =  _service.Get();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok();
    }

    [HttpPut]
    public IActionResult Put()
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        return Ok();
    }
}