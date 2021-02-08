using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Board
{
    public interface ISquare : IChessboardDependency
    {
        IPosition Position { get; set; }

        bool IsEmpty { get; set; }

        IPiece OccupiedBy { get; set; }

        List<IPiece> Observers { get; set; }
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
    }
}
