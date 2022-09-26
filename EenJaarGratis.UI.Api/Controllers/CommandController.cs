using EenJaarGratis.Services.Handlers.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EenJaarGratis.UI.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CommandController : Controller
{
    private readonly IMediator _mediator;
    
    public CommandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public void Test(CancellationToken cancellationToken)
    {
        _mediator.Send(new TestRequest(), cancellationToken);
    }
}