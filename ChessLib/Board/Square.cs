using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Board
{
    public interface ISquare : IChessboardDependency
    {
        public IPosition Position { get; set; }

        //public IChessboard Chessboard { get; }

        public bool IsEmpty { get; set; }

        public IPiece OccupiedBy { get; set; }

        public List<IPiece> Observers { get; set; }
    }

    [Serializable]
    public class Square : ISquare
    {
        public Square(IPosition position, IChessboard chessboard)
        {
            Position = position;
            Chessboard = chessboard;
            IsEmpty = true;
            Observers = new List<IPiece>();
        }

        public IChessboard Chessboard { get; }

        public IPosition Position { get; set; }

        public bool IsEmpty { get; set; }

        public IPiece OccupiedBy { get; set; }

        public List<IPiece> Observers { get; set; }

        public object Clone()
        {
            //var clone = (ISquare)MemberwiseClone();
            var clone = new Square((IPosition)Position.Clone(), (IChessboard)Chessboard.Clone());
            clone.IsEmpty = IsEmpty;
            clone.OccupiedBy = (IPiece)OccupiedBy.Clone();
            clone.Observers = (List<IPiece>)Observers.ConvertAll(item => (IPiece)item.Clone());
            return clone;
        }
    }
}
