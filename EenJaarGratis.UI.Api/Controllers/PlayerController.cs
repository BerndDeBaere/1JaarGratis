using EenJaarGratis.Common;
using EenJaarGratis.Services.Handlers.Requests.Player;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EenJaarGratis.UI.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;
    private readonly IMediator _mediator;

    private readonly IHubContext<SignalRHub> _hubContext;

    public PlayerController(ILogger<PlayerController> logger, IMediator mediator,
        IHubContext<SignalRHub> hubContext)
    {
        _logger = logger;
        _mediator = mediator;
        _hubContext = hubContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetPlayersRequest(), cancellationToken));
    }

    [HttpGet("Scoreboard")]
    public async Task<IActionResult> GetScoreboard(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get ScoreBoard");
        return Ok(await _mediator.Send(new GetScoreBoardPlayersRequest(), cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePlayerRequest request)
    {
        _logger.LogInformation("Create player");
        var result = Ok(await _mediator.Send(request));
        await _hubContext.Clients.All.SendAsync("UpdatePlayers");
        return result;
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdatePlayerRequest request)
    {
        _logger.LogInformation("Update player");
        var result = Ok(await _mediator.Send(request));
        await _hubContext.Clients.All.SendAsync("UpdatePlayers");
        return result;
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Delete player with id {id}", id);
        var result = Ok(await _mediator.Send(new DeletePlayerRequest { Id = id }, cancellationToken));
        await _hubContext.Clients.All.SendAsync("UpdatePlayers", cancellationToken);
        return result;
    }

    [HttpPost("{id:int}/QuestionGroup/{questionGroupId:int}")]
    public async Task<IActionResult> PostQuestionGroupPlayer([FromRoute] int id, [FromRoute] int questionGroupId,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create Playergroup");
        return Ok(await _mediator.Send(new CreateQuestionGroupPlayerRequest
        {
            PlayerId = id,
            QuestionGroupId = questionGroupId
        }, cancellationToken));
    }
}