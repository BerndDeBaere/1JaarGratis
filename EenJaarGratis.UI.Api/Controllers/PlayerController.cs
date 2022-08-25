using EenJaarGratis.Service.Handlers.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EenJaarGratis.UI.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;
    private readonly IMediator _mediator;

    public PlayerController(ILogger<PlayerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Get(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all players");
        return Ok(_mediator.Send(new GetPlayersRequest(), cancellationToken));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        _logger.LogInformation("Get player with id {id}", id);
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult Post(CreatePlayerRequest request)
    {
        _logger.LogInformation("Create player");
        return Ok(_mediator.Send(request));
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