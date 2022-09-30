using EenJaarGratis.Service.Storage.Domain;
using Microsoft.AspNetCore.SignalR;

public class SignalRHub: Hub
{
    public void ReloadScoreboard() => Clients.Others.SendAsync("ReloadScoreboard");
    public void ReloadPlayers() => Clients.Others.SendAsync("ReloadPlayers");
    public void ShowQuestion(string question) => Clients.Others.SendAsync("ShowQuestion", question);
    public void HideQuestion() => Clients.Others.SendAsync("HideQuestion");
    public void SelectRandomPlayers() => Clients.All.SendAsync("SelectRandomPlayers");
}