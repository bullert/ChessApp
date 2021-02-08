using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessApp.Data
{
    public class SignalStateContainer : StateContainer
    {
        private HubConnection hubConnection;

        public async Task Run(int userId)
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/chatHub")
                .Build();

            hubConnection.On<string, string>("ReceiveMessage", (userName, message) =>
            {
                OnPropertyChanged();
            });

            await hubConnection.StartAsync();

            await hubConnection.SendAsync("SetUserName", userId);
        }

        public Task JoinRoom(int roomId)
        {
            if (!IsConnected)
                return null;
            var task = hubConnection.SendAsync("AddToGroupAsync", roomId.ToString());
            OnPropertyChanged();
            return task;
        }

        public Task LeaveRoom(int roomId)
        {
            if (!IsConnected)
                return null;
            var task = hubConnection.SendAsync("RemoveFromGroup", roomId.ToString());
            OnPropertyChanged();
            return task;
        }

        public Task SendDirectMessage(int userId, string message)
        {
            if (!IsConnected)
                return null;
            return hubConnection.SendAsync("SendDirectMessage", userId.ToString(), message);
        }

        public Task SendGroupMessage(int roomId, string message)
        {
            if (!IsConnected)
                return null;
            return hubConnection.SendAsync("SendGroupMessage", roomId.ToString(), message);
        }

        public Task SendMessageToAll(string message)
        {
            if (!IsConnected)
                return null;
            return hubConnection.SendAsync("SendMessageToAll", message);
        }

        public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

        public async ValueTask DisposeAsync()
        {
            await hubConnection.DisposeAsync();
        }
    }
}
