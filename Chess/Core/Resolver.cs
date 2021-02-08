using Chess.Board;
using Chess.Moves;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Core
{
    public interface IResolver
    {
        void PresolveSquares(List<ISquare> squares);

        void PresolvePieces(List<IPiece> pieces, IMoveRegister moveRegister);
    }

    public class Resolver : IResolver
    {
        public Resolver(IGame instance)
        {
             
        }

        public void PresolveSquares(List<ISquare> squares)
        {
            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].Observers.Clear();
            }
        }

        public void PresolvePieces(List<IPiece> pieces, IMoveRegister moveRegister)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].Presolve(moveRegister);
            }
        }
    }
}
