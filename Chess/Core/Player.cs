using Chess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Core
{
    public interface IPlayer
    {
        int Id { get; set; }

        Color Color { get; set; }
    }
    
    public class Player : IPlayer
    {
        public Player(int id, Color color)
        {
            Id = id;
            Color = color;
        }

        public int Id { get; set; }

        public Color Color { get; set; }
    }
}
