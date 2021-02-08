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
    public class Queen : Piece, IPiece
    {
        public Queen(Color color) : base(color)
        {
            var moves = new List<IMove>();

            var sides = new IPosition[8]
            {
                new Position(-1, 1),
                new Position( 1, 1),
                new Position( 1,-1),
                new Position(-1,-1),
                new Position(-1, 0),
                new Position( 1, 0),
                new Position( 0,-1),
                new Position( 0, 1)
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

        public Queen(Color color, ISquare square, IChessboard chessboard, List<IMove> moves, List<IMove> legalMoves) : base(color, square, chessboard, moves, legalMoves)
        {

        }
    }
}
