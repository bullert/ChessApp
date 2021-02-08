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
    public interface IMove : ICloneable
    {
        public IPiece Piece { get; set; }

        public IPosition Pattern { get; set; }

        public IPosition Origin { get; set; }

        public IPosition Destination { get; set; }

        public List<IMoveCondition> Conditions { get; set; }

        public void Initialize();

        public void Presolve(IMoveRegister moveRegister);

        public void Execute();

        //bool IsLegal();

        //public void Execute();

        //public bool Test();

        //bool VerifySquare(ISquare square);

        //public ISquare GetDestinationSquare(IPosition offset);
    }

    [Serializable]
    public abstract class Move : IMove
    {
        protected Move(IPiece piece, IPosition pattern)
        {
            Piece = piece;
            Pattern = pattern;
            //Origin = Position.Copy(piece.Square.Position);
            //Destination = Position.Add(Origin, Pattern);
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

            //Console.WriteLine(Piece.Square.Position.ToAlgebraicNotation());
            //Console.WriteLine("----------------");
            //Console.WriteLine(Piece);
            //Console.WriteLine(Piece.Color);
            //Console.WriteLine(Origin.ToAlgebraicNotation());
            //Console.WriteLine(Pattern.ToAlgebraicNotation());
            //Console.WriteLine(Destination.ToAlgebraicNotation());

            if (IsLegal(moveRegister))
            {
                //Console.WriteLine("ta");
                var square = Piece.Chessboard.GetSquare(Destination);
                //Piece.PotentionalPositions.Add(square);
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
            //var copy = this.DeepClone();
            //Piece.Chessboard.MoveRegister.Register(copy);
            Piece.Leave();
            var square = Piece.Chessboard.GetSquare(Destination);
            if (!square.IsEmpty)
            {
                Piece.Chessboard.CapturedPieces.Add(square.OccupiedBy);
                Piece.Chessboard.Pieces.Remove(square.OccupiedBy);
            }
            
            Piece.Claim(square);
            //Console.WriteLine("e");
            //Console.WriteLine(Piece.Chessboard.CapturedPieces.Count);
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
