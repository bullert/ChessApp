using Chess.Board;
using Chess.Conditions;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Moves
{
    [Serializable]
    public class SingleForwardMove : DiscreteMove, IDiscreteMove
    {
        public SingleForwardMove(IPiece piece) : base(piece, new Position(0, 1))
        {
            Conditions = new List<IMoveCondition>()
            {
                new NoCaptureMoveCondition()
            };
        }
    }
}
