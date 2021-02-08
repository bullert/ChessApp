using Chess.Board;
using Chess.Core;
using Chess.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Conditions
{
    [Serializable]
    public class NoSelfCaptureMoveCondition: MoveCondition, IMoveCondition
    {
        override public bool Verify(IMove move, IMoveRegister moveRegister)
        {
            if (move.Piece.Chessboard.IsPositionOutOfBoard(move.Destination))
                return false;

            ISquare square = move.Piece.Chessboard.GetSquare(move.Destination);
            
            if (!square.IsEmpty && !square.OccupiedBy.IsEnemyOf(move.Piece))
                return false;

            return true;
        }
    }
}
