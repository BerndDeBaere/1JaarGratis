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
    public IActionResult Get(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all questions");
        return Ok(_mediator.Send(new GetQuestionRequest(), cancellationToken));
    }

    [HttpPost]
    public IActionResult Post(CreateQuestionRequest request)
    {
        _logger.LogInformation("Create question");
        return Ok(_mediator.Send(request));
    }

    [HttpPut]
    public IActionResult Put(UpdateQuestionRequest request)
    {
        _logger.LogInformation("Update question");
        return Ok(_mediator.Send(request));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Delete question with id {id}", id);
        return Ok(_mediator.Send(new DeleteQuestionRequest {Id = id}, cancellationToken));
    }
}