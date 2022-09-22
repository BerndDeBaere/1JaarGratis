using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EenJaarGratis.UI.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CommandController : Controller
{
    private readonly IHubContext<SignalRHub> _hubContext;

    public CommandController(IHubContext<SignalRHub> hubContext)
    {
        _hubContext = hubContext;
    }
}