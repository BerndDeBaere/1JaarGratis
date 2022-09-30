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
    private readonly IMediator _mediator;


    public PlayerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetPlayersRequest(), cancellationToken));
    }

    [HttpGet("Random")]
    public async Task<IActionResult> GetRandom(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetRandomPlayersRequest(), cancellationToken));
    }

    
    [HttpGet("Scoreboard")]
    public async Task<IActionResult> GetScoreboard(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetScoreBoardPlayersRequest(), cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePlayerRequest request)
    {
        var result = Ok(await _mediator.Send(request));
        return result;
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdatePlayerRequest request)
    {
        var result = Ok(await _mediator.Send(request));
        return result;
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = Ok(await _mediator.Send(new DeletePlayerRequest { Id = id }, cancellationToken));
        return result;
    }

    [HttpPost("{id:int}/QuestionGroup/{questionGroupId:int}")]
    public async Task<IActionResult> PostQuestionGroupPlayer([FromRoute] int id, [FromRoute] int questionGroupId,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new CreateQuestionGroupPlayerRequest
        {
            PlayerId = id,
            QuestionGroupId = questionGroupId
        }, cancellationToken));
    }
    
    [HttpDelete("{id:int}/QuestionGroup/{questionGroupId:int}")]
    public async Task<IActionResult> DeleteQuestionGroupPlayer([FromRoute] int id, [FromRoute] int questionGroupId,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new DeleteQuestionGroupPlayerRequest
        {
            PlayerId = id,
            QuestionGroupId = questionGroupId
        }, cancellationToken));
    }
}