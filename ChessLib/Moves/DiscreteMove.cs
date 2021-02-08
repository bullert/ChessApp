using Chess.Board;
using Chess.Conditions;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Moves
{
    public interface IDiscreteMove : IMove
    {
        //public IPosition Pattern { get; set; }
    }

    [Serializable]
    public class DiscreteMove : Move, IDiscreteMove
    {
        public DiscreteMove(IPiece piece, IPosition pattern) : base(piece, pattern)
        {

        }

        public override object Clone()
        {
            var move = new DiscreteMove((IPiece)Piece.Clone(), (IPosition)Pattern.Clone());
            move.Origin = (IPosition)Origin.Clone();
            move.Destination = (IPosition)Destination.Clone();
            //move.Conditions = (List<IMoveCondition>)Conditions.ConvertAll(
            //        item => (IMoveCondition)item.Clone()
            //    );

            return move;
        }
    }
}
