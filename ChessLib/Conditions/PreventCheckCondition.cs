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

            //var copy = move.Piece.Chessboard.DeepClone();
            //Console.WriteLine("afsf");

            return true;
            //var copy = move.Piece.Chessboard.DeepClone();

            //var copy = move.Piece.Chessboard.Clone();
            //ISquare originSquare = move.Piece.Square;
            //ISquare destinationSquare = move.Piece.Chessboard.GetSquare(move.Destination);

            //IPiece enemy = null;
            //if (!destinationSquare.IsEmpty && destinationSquare.OccupiedBy.IsEnemyOf(move.Piece))
            //    enemy = destinationSquare.OccupiedBy;

            //move.Piece.Leave();
            //move.Piece.Claim(destinationSquare);

            //var king = move.Piece.Chessboard.GetPieces(typeof(King), Color.WHITE);
            //int observers = king[0].Square.Observers.Count;

            //move.Piece.Leave();
            //move.Piece.Claim(originSquare);

            //if (enemy != null)
            //    enemy.Claim(destinationSquare);

            //Console.WriteLine(king.Count);
            //Console.WriteLine(king[0].Square.Position.ToString());
            //Console.WriteLine(observers);
            //Console.WriteLine(king[0].Square.Observers.Count);

            //if (observers > 0)
            //    return false;

            //return true;
        }
    }
}
