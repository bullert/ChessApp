using Chess.Board;
using Chess.Enums;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Core
{
    public interface IGame
    {

    }

    public class Game : IGame
    {
        public Game()
        {
            Resolver = new Resolver(this);

            MoveRegister = new MoveRegister();

            Chessboard = new Chessboard(MoveRegister, 8);

            Chessboard.SetPiece(new Pawn(Color.WHITE), new Position(0, 1));
            Chessboard.SetPiece(new Pawn(Color.WHITE), new Position(1, 1));
            Chessboard.SetPiece(new Knight(Color.WHITE), new Position(2, 1));
            Chessboard.SetPiece(new Bishop(Color.WHITE), new Position(3, 1));
            Chessboard.SetPiece(new Rook(Color.WHITE), new Position(4, 1));
            Chessboard.SetPiece(new Queen(Color.WHITE), new Position(5, 1));
            Chessboard.SetPiece(new King(Color.WHITE), new Position(6, 1));
            Chessboard.SetPiece(new Bishop(Color.WHITE), new Position(5, 2));

            Chessboard.SetPiece(new Pawn(Color.BLACK), new Position(0, 6));
            Chessboard.SetPiece(new Bishop(Color.BLACK), new Position(1, 6));
            Chessboard.SetPiece(new Knight(Color.BLACK), new Position(2, 6));
            Chessboard.SetPiece(new Bishop(Color.BLACK), new Position(3, 6));
            Chessboard.SetPiece(new Rook(Color.BLACK), new Position(4, 6));
            Chessboard.SetPiece(new Queen(Color.BLACK), new Position(5, 6));
            Chessboard.SetPiece(new King(Color.BLACK), new Position(6, 6));
            Chessboard.SetPiece(new Queen(Color.BLACK), new Position(6, 5));

            Chessboard.Initialize();
        }

        public IChessboard Chessboard { get; set; }

        public IMoveRegister MoveRegister { get; set; }

        public IResolver Resolver { get; set; }

        public void OnUserInput()
        {
            Resolver.PresolveSquares(Chessboard.Squares);
            Resolver.PresolvePieces(Chessboard.Pieces, MoveRegister);
        }
    }
}
