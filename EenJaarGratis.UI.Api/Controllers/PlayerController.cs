using Microsoft.AspNetCore.Mvc;

namespace EenJaarGratis.UI.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(ILogger<PlayerController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Get all players");
        throw new NotImplementedException();
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        _logger.LogInformation("Get player with id {id}", id);
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult Post()
    {
        _logger.LogInformation("Create player");
        throw new NotImplementedException();
    }

    [HttpPut]
    public IActionResult Put()
    {
        _logger.LogInformation("Update player");
        throw new NotImplementedException();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Delete player with id {id}", id);
        throw new NotImplementedException();
    }
}