using System.ComponentModel;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using ChessApp.Data;
using Chess.Core;

namespace ChessApp.Data
{
    public class GameStateContainer : StateContainer
    {
        public GameStateContainer()
        {
            game = new Game();
        }

        protected Game game;
        public Game Game
        {
            get => game;
            set
            {
                game = value;
                OnPropertyChanged();
            }
        }
    }
}
