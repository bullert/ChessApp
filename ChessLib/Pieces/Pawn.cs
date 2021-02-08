using Chess;
using Chess.Enums;
using Chess.Conditions;
using Chess.Moves;
using System;
using System.Collections.Generic;
using System.Text;
using Chess.Board;

namespace Chess.Pieces
{
    [Serializable]
    public class Pawn : Piece, IPiece
    {
        public Pawn(Color color) : base(color)
        {
            var legalMoves = new List<IMove>();

            var m0 = new DiscreteMove(this, new Position(-1, 1));
            m0.Conditions = new List<IMoveCondition>() {
                    new CaptureRequiredMoveCondition()
                };
            var m1 = new DiscreteMove(this, new Position(1, 1));
            m1.Conditions = new List<IMoveCondition>() {
                    new CaptureRequiredMoveCondition()
                };

            legalMoves.Add(new SingleForwardMove(this));
            legalMoves.Add(new EntryDoubleForwardMove(this));
            legalMoves.Add(m0);
            legalMoves.Add(m1);
            legalMoves.Add(new EnPassantMove(this, new Position(-1, 1)));
            legalMoves.Add(new EnPassantMove(this, new Position(1, 1)));

            Moves = legalMoves;
        }

        public Pawn(Color color, ISquare square, IChessboard chessboard, List<IMove> moves, List<IMove> legalMoves) : base(color, square, chessboard, moves, legalMoves)
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
