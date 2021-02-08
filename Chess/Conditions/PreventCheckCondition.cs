using Chess.Board;
using Chess.Core;
using Chess.Enums;
using Chess.Moves;
using Chess.Pieces;
using Chess.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Conditions
{
    [Serializable]
    public class PreventCheckCondition : MoveCondition, IMoveCondition
    {
        override public bool Verify(IMove move, IMoveRegister moveRegister)
        {
            if (move.Piece.Chessboard.IsPositionOutOfBoard(move.Destination))
                return false;

            return true;
        }
    }
}
