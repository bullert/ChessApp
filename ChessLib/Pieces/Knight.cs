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
    class Knight : Piece, IPiece
    {
        public Knight(Color color) : base(color)
        {
            var moves = new List<IMove>();

            var sides = new IPosition[4]
            {
                new Position(-1, 1),
                new Position( 1, 1),
                new Position( 1,-1),
                new Position(-1,-1),
            };

            for (int i = 0; i < sides.Length; i++)
            {
                var m0 = new DiscreteMove(this, new Position(sides[i].File, sides[i].Rank * 2));
                m0.Conditions = new List<IMoveCondition>() {
                    new NoSelfCaptureMoveCondition()
                };
                var m1 = new DiscreteMove(this, new Position(sides[i].File * 2, sides[i].Rank));
                m1.Conditions = new List<IMoveCondition>() {
                    new NoSelfCaptureMoveCondition()
                };
                moves.Add(m0);
                moves.Add(m1);
            }

            Moves = moves;
        }

        public Knight(Color color, ISquare square, IChessboard chessboard, List<IMove> moves, List<IMove> legalMoves) : base(color, square, chessboard, moves, legalMoves)
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
