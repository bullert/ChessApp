using Chess.Board;
using Chess.Conditions;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Moves
{
    public interface IDiscreteMove : IMove
    {
        
    }

    [Serializable]
    public class DiscreteMove : Move, IDiscreteMove
    {
        public DiscreteMove(IPiece piece, IPosition pattern) : base(piece, pattern)
        {

        }
    }
}
