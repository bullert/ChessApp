using Chess.Board;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Moves
{
    public interface IContinuousMove : IMove
    {
        public List<IPosition> Path { get; set; }
    }

    [Serializable]
    public class ContinuousMove : Move, IContinuousMove
    {
        public ContinuousMove(IPiece piece, IPosition pattern, List<IPosition> path) : base(piece, pattern)
        {
            Path = path;
        }

        public List<IPosition> Path { get; set; }

        public override void Initialize()
        {
            base.Initialize();
            for (int i = 0; i < Path.Count; i++)
            {
                Path[i] = Piece.Chessboard.ColorMatrixDict[Piece.Color].Transform(Path[i]);
            }
        }

        public override object Clone()
        {
            var move = new ContinuousMove(
                    (IPiece)Piece.Clone(), 
                    (IPosition)Pattern.Clone(),
                    (List<IPosition>)Path.ConvertAll(item => (IPosition)item.Clone())
                );
            move.Origin = (IPosition)Origin.Clone();
            move.Destination = (IPosition)Destination.Clone();
            //move.Conditions = (List<IMoveCondition>)Conditions.ConvertAll(
            //        item => (IMoveCondition)item.Clone()
            //    );
            
            return move;
        }
    }
}
