using Chess.Board;
using Chess.Moves;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Moves
{
    [Serializable]
    public class StandardDiscreteMove : DiscreteMove, IMove
    {
        public StandardDiscreteMove(IPiece piece, IPosition pattern) : base(piece, pattern)
        {

        }

        //public override bool Test()
        //{
        //    ISquare destinationSquare = GetDestinationSquare();

        //    if (destinationSquare == null)
        //        return false;

        //    if (!destinationSquare.IsEmpty && !destinationSquare.OccupiedBy.IsEnemyOf(Piece))
        //        return false;

        //    return true;
        //}
    }
}
