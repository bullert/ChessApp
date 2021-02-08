using Chess.Board;
using Chess.Conditions;
using Chess.Core;
using Chess.Pieces;
using Chess.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Moves
{
    public interface IMove
    {
        IPiece Piece { get; set; }

        IPosition Pattern { get; set; }

        IPosition Origin { get; set; }

        IPosition Destination { get; set; }

        List<IMoveCondition> Conditions { get; set; }

        void Initialize();

        void Presolve(IMoveRegister moveRegister);

        void Execute();
    }

    [Serializable]
    public abstract class Move : IMove
    {
        protected Move(IPiece piece, IPosition pattern)
        {
            Piece = piece;
            Pattern = pattern;
        }

        public IPiece Piece { get; set; }

        public IPosition Pattern { get; set; }

        public IPosition Origin { get; set; }

        public IPosition Destination { get; set; }

        public List<IMoveCondition> Conditions { get; set; }

        public virtual void Initialize()
        {
            Pattern = Piece.Chessboard.ColorMatrixDict[Piece.Color].Transform(Pattern);
        }

        public virtual void Presolve(IMoveRegister moveRegister)
        {
            Origin = Position.Copy(Piece.Square.Position);
            Destination = Position.Add(Origin, Pattern);

            if (IsLegal(moveRegister))
            {
                var square = Piece.Chessboard.GetSquare(Destination);
                Piece.LegalMoves.Add(this);
                square.Observers.Add(Piece);
            }
        }

        protected virtual bool IsLegal(IMoveRegister moveRegister)
        {
            for (int i = 0; i < Conditions.Count; i++)
            {
                if (!Conditions[i].Verify(this, moveRegister))
                    return false;
            }

            return true;
        }

        public virtual void Execute()
        {
            Piece.Leave();
            var square = Piece.Chessboard.GetSquare(Destination);
            if (!square.IsEmpty)
            {
                Piece.Chessboard.CapturedPieces.Add(square.OccupiedBy);
                Piece.Chessboard.Pieces.Remove(square.OccupiedBy);
            }
            
            Piece.Claim(square);
        }
    }
}
