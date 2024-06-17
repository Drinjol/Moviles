
using Microsoft.AspNet.SignalR;

public class ChatHub : Hub
{
    public void SendMessage(string user, string message)
    {
        Clients.All.ReceiveMessage(user, message);
    }
}
