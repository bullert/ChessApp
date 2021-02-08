using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Data
{

    public class ChatHub : Hub
    {
        public string NameIdentifier { get; set; }

        public string Name { get; set; }

        public HubCallerContext HubContext { get; set; }

        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public void SetUserNameIdentifier(string nameIdentifier)
        {
            NameIdentifier = nameIdentifier;
        }

        public void SetUserName(string name)
        {
            Name = name;
            _connections.Add(Name, Context.ConnectionId);
        }

        public async Task AddToGroupAsync(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task RemoveFromGroupAsync(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public void SendMessage(string who, string message)
        {
            Clients.All.SendAsync("ReceiveMessage", Context.ConnectionId, message);
        }

        public void SendMessageToAll(string message)
        {
            Clients.All.SendAsync("ReceiveMessage", Context.ConnectionId, message);
        }

        public void SendDirectMessage(string userName, string message)
        {
            Clients.Client(userName).SendAsync("ReceiveMessage", Context.ConnectionId, message);
        }

        public void SendGroupMessage(string groupName, string message)
        {
            Clients.Group(groupName).SendAsync("ReceiveMessage", Context.ConnectionId, message);
        }

        public override Task OnConnectedAsync()
        {
            var username = Context.GetHttpContext().Request.Query["Name"];
            _connections.Add("afsaf", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
