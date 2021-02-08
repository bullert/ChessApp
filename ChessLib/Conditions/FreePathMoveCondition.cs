using Chess.Board;
using Chess.Core;
using Chess.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Conditions
{
    [Serializable]
    public class FreePathMoveCondition : ContinuousMoveCondition, IContinuousMoveCondition
    {
        public override bool Verify(IContinuousMove move, IMoveRegister moveRegister)
        {
            if (move.Piece.Chessboard.IsPositionOutOfBoard(move.Destination))
                return false;

            //if (move.Piece is Chess.Pieces.Bishop)
            //{
            //    Console.WriteLine("--------");
            //    Console.WriteLine(move.Origin);
            //    Console.WriteLine(move.Destination);
            //    Console.WriteLine("++++++++");
            //}

            for (int i = 0; i < move.Path.Count; i++)
            {
                //if (move.Piece.Chessboard.IsPositionOutOfBoard(move.Path[i]))
                //    return false;

                //if (move.Piece is Chess.Pieces.Bishop)
                //{
                //    Console.WriteLine(Position.Add(move.Origin, move.Path[i]));
                //}

                ISquare square = move.Piece.Chessboard.GetSquare(
                        Position.Add(move.Origin, move.Path[i])
                    );
                
                if (!square.IsEmpty)
                    return false;
            }

            return true;
        }
    }
}
