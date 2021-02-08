using Chess;
using Chess.Board;
using Chess.Conditions;
using Chess.Enums;
using Chess.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Pieces
{
    [Serializable]
    public class Bishop : Piece, IPiece
    {
        public Bishop(Color color) : base(color)
        {
            var moves = new List<IMove>();

            var sides = new IPosition[4]
            {
                new Position(-1, 1),
                new Position( 1, 1),
                new Position( 1,-1),
                new Position(-1,-1)
            };

            for (int i = 0; i < sides.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    var path = new List<IPosition>();

                    for (int k = 1; k < j; k++)
                    {
                        path.Add(Position.Scale(sides[i], k));
                    }

                    var m = new ContinuousMove(this, Position.Scale(sides[i], j), path);
                    m.Conditions = new List<IMoveCondition>() {
                        new NoSelfCaptureMoveCondition(),
                        new FreePathMoveCondition(),
                    };
                    moves.Add(m);
                }
            }

            Moves = moves;
        }

        public Bishop(Color color, ISquare square, IChessboard chessboard, List<IMove> moves, List<IMove> legalMoves) : base(color, square, chessboard, moves, legalMoves)
        {

        }

        public override object Clone()
        {
            var piece = new Pawn(
                    Color,
                    (ISquare)Square.Clone(),
                    (IChessboard)Chessboard.Clone(),
                    (List<IMove>)Moves.ConvertAll(item => (IMove)item.Clone()),
                    (List<IMove>)LegalMoves.ConvertAll(item => (IMove)item.Clone())
                );

            return piece;
        }
    }
}
