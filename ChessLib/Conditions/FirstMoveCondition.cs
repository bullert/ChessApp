using Chess.Board;
using Chess.Core;
using Chess.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Conditions
{
    [Serializable]
    public class FirstMoveCondition : MoveCondition, IMoveCondition
    {
        public FirstMoveCondition()
        {

        }

        public override bool Verify(IMove move, IMoveRegister moveRegister)
        {
            if (move.Piece.Chessboard.IsPositionOutOfBoard(move.Destination))
                return false;

            ISquare square = move.Piece.Chessboard.GetSquare(move.Destination);
            
            if (moveRegister.GetAllMovesOf(move.Piece).Count != 0)
                return false;

            return true;
        }
    }
}
