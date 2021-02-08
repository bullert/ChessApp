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
    class King : Piece, IPiece
    {
        public King(Color color) : base(color)
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
                var m = new DiscreteMove(this, sides[i]);
                m.Conditions = new List<IMoveCondition>() {
                        new NoSelfCaptureMoveCondition()
                    };
                moves.Add(m);
            }

            Moves = moves;
        }

        public King(Color color, ISquare square, IChessboard chessboard, List<IMove> moves, List<IMove> legalMoves) : base(color, square, chessboard, moves, legalMoves)
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
