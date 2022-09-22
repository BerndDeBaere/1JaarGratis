using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Requests.Question;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EenJaarGratis.UI.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionController : Controller
{
    private readonly ILogger<QuestionController> _logger;
    private readonly IMediator _mediator;

    public QuestionController(ILogger<QuestionController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all questions");
        return Ok(await _mediator.Send(new GetQuestionRequest(), cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateQuestionRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create question");
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateQuestionRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Update question");
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Delete question with id {id}", id);
        return Ok(await _mediator.Send(new DeleteQuestionRequest {Id = id}, cancellationToken));
    }
    
    [HttpGet("{id:int}/QuestionGroup")]
    public async Task<IActionResult> GetQuestionGroup(int id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get Playergroup");
        return Ok(await _mediator.Send(new GetQuestionGroupRequest{QuestionId = id}, cancellationToken));
    }

    [HttpPost("{id:int}/QuestionGroup")]
    public async Task<IActionResult> PostQuestionGroup([FromRoute]int id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create Playergroup");
        return Ok(await _mediator.Send(new CreateQuestionGroupRequest
        {
            QuestionId = id
        }, cancellationToken));
    }
    [HttpDelete("{id:int}/QuestionGroup/{questionGroupId:int}")]
    public async Task<IActionResult> DeleteQuestionGroup(int id, int questionGroupId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create Playergroup");
        return Ok(await _mediator.Send(new DeleteQuestionGroupRequest
        {
            QuestionId = id,
            QuestionGroupId = questionGroupId
        }, cancellationToken));
    }
    
    
    [HttpPost("Import")]
    public async Task<IActionResult> ImportQuestionGroup(ImportQuestionRequest request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request));
    }
}