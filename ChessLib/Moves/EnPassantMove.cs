using Chess.Board;
using Chess.Conditions;
using Chess.Moves;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Moves
{
    [Serializable]
    public class EnPassantMove : DiscreteMove, IDiscreteMove
    {
        public EnPassantMove(IPiece piece, IPosition pattern) : base(piece, pattern)
        {
            Conditions = new List<IMoveCondition>()
            {
                new EnPassantMoveCondition()
            };
        }

        public override void Execute()
        {
            base.Execute();

            ISquare enemyCurrentSquare = Piece.Chessboard.GetSquare(
                Position.Add(
                    Destination,
                    Piece.Chessboard.GetRelativePosition(Piece.Color, new Position(0, -1))
                ));
            
            Piece.Chessboard.CapturedPieces.Add(enemyCurrentSquare.OccupiedBy);
            Piece.Chessboard.Pieces.Remove(enemyCurrentSquare.OccupiedBy);
            enemyCurrentSquare.OccupiedBy.Leave();

            //Console.WriteLine("a");
        }
    }
}
