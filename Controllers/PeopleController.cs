using houses.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace houses.Controllers;

[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IPeopleService _service;
    public PeopleController(IPeopleService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.Get());
    }
}