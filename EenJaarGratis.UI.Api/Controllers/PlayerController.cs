using EenJaarGratis.Services.Handlers.Requests.Player;
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
    
    [HttpGet("Scoreboard")]
    public IActionResult GetScoreboard(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get ScoreBoard");
        return Ok(_mediator.Send(new GetScoreBoardPlayersRequest(), cancellationToken));
    }

    [HttpPost]
    public IActionResult Post(CreatePlayerRequest request)
    {
        _logger.LogInformation("Create player");
        return Ok(_mediator.Send(request));
    }

    [HttpPut]
    public IActionResult Put(UpdatePlayerRequest request)
    {
        _logger.LogInformation("Update player");
        return Ok(_mediator.Send(request));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Delete player with id {id}", id);
        return Ok(_mediator.Send(new DeletePlayerRequest {Id = id}, cancellationToken));
    }
    
    [HttpPost("{id:int}/QuestionGroup/{questionGroupId:int}")]
    public async Task<IActionResult> PostQuestionGroupPlayer([FromRoute]int id, [FromRoute]int questionGroupId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create Playergroup");
        return Ok(await _mediator.Send(new CreateQuestionGroupPlayerRequest
        {
            PlayerId = id,
            QuestionGroupId = questionGroupId
        }, cancellationToken));
    }
}