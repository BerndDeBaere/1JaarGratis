using Microsoft.AspNetCore.SignalR;

public class SignalRHub: Hub
{
    public void ReloadScoreboard()
    {
        Clients.All.SendAsync("ReloadScoreboard");
    }
    public void StartTimer(int questionId)
    {
        Clients.All.SendAsync("StartTimer", questionId);
    }
}