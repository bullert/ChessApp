using Chess.Board;
using Chess.Core;
using Chess.Moves;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Conditions
{
    [Serializable]
    public class EnPassantMoveCondition : MoveCondition, IMoveCondition
    {
        public EnPassantMoveCondition()
        {

        }

        public override bool Verify(IMove move, IMoveRegister moveRegister)
        {
            if (move.Piece.Chessboard.IsPositionOutOfBoard(move.Destination))
                return false;

            ISquare destinationSquare = move.Piece.Chessboard.GetSquare(move.Destination);
            
            if (!destinationSquare.IsEmpty)
                return false;

            ISquare enemyCurrentSquare = move.Piece.Chessboard.GetSquare(
                Position.Add(
                    destinationSquare.Position,
                    move.Piece.Chessboard.GetRelativePosition(move.Piece.Color, new Position(0, -1))
                ));

            if (enemyCurrentSquare.IsEmpty || 
                !enemyCurrentSquare.OccupiedBy.IsEnemyOf(move.Piece) || 
                !(enemyCurrentSquare.OccupiedBy is Pawn))
                return false;

            var enemyLastMove = moveRegister.GetMoveOfAt(enemyCurrentSquare.OccupiedBy.Color, -1);

            if (enemyLastMove == null)
                return false;
            
            if (enemyLastMove.Piece != enemyCurrentSquare.OccupiedBy)
                return false;
            
            if ((Position)Position.Subtract(enemyLastMove.Origin, enemyLastMove.Destination) !=
                (Position)move.Piece.Chessboard.GetRelativePosition(move.Piece.Color, new Position(0, 2)))
                return false;

            return true;
        }
    }
}
