using Microsoft.AspNetCore.SignalR;

public class SignalRHub: Hub
{
    public void ReloadScoreboard() => Clients.All.SendAsync("ReloadScoreboard");
    public void ReloadPlayers() => Clients.All.SendAsync("ReloadPlayers");
}