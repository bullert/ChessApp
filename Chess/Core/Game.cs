using Chess.Board;
using Chess.Enums;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Core
{
    public interface IGame
    {
        GameState GameState { get; set; }

        IEnumerable<IPlayer> Players { get; set; }

        IPlayer CurrentPlayer { get; set; }

        IChessboard Chessboard { get; set; }

        IMoveRegister MoveRegister { get; set; }

        IResolver Resolver { get; set; }

        void NextTurn();

        void SwitchPlayer();

        void UpdateCurrentPlayer();

        void Solve();
    }

    public class Game : IGame
    {
        private int currentPlayerIndex = 0;

        public GameState GameState { get; set; }

        public IEnumerable<IPlayer> Players { get; set; }

        public IPlayer CurrentPlayer { get; set; }

        public IChessboard Chessboard { get; set; }

        public IMoveRegister MoveRegister { get; set; }

        public IResolver Resolver { get; set; }

        public Game()
        {
            Players = new List<IPlayer>();

            Resolver = new Resolver(this);

            MoveRegister = new MoveRegister();

            Chessboard = new Chessboard(MoveRegister, 8);

            for (int i = 0; i < Chessboard.Length; i++)
            {
                Chessboard.SetPiece(new Pawn(Color.WHITE), new Position(i, 1));
                Chessboard.SetPiece(new Pawn(Color.BLACK), new Position(i, 6));
            }

            Chessboard.SetPiece(new Rook(Color.WHITE), new Position(0, 0));
            Chessboard.SetPiece(new Knight(Color.WHITE), new Position(1, 0));
            Chessboard.SetPiece(new Bishop(Color.WHITE), new Position(2, 0));
            Chessboard.SetPiece(new Queen(Color.WHITE), new Position(3, 0));
            Chessboard.SetPiece(new King(Color.WHITE), new Position(4, 0));
            Chessboard.SetPiece(new Bishop(Color.WHITE), new Position(5, 0));
            Chessboard.SetPiece(new Knight(Color.WHITE), new Position(6, 0));
            Chessboard.SetPiece(new Rook(Color.WHITE), new Position(7, 0));

            Chessboard.SetPiece(new Rook(Color.BLACK), new Position(0, 7));
            Chessboard.SetPiece(new Knight(Color.BLACK), new Position(1, 7));
            Chessboard.SetPiece(new Bishop(Color.BLACK), new Position(2, 7));
            Chessboard.SetPiece(new Queen(Color.BLACK), new Position(3, 7));
            Chessboard.SetPiece(new King(Color.BLACK), new Position(4, 7));
            Chessboard.SetPiece(new Bishop(Color.BLACK), new Position(5, 7));
            Chessboard.SetPiece(new Knight(Color.BLACK), new Position(6, 7));
            Chessboard.SetPiece(new Rook(Color.BLACK), new Position(7, 7));

            Chessboard.Initialize();

            GameState = GameState.INITIALIZED;
        }

        public void Start()
        {
            GameState = GameState.RUNNING;
            UpdateCurrentPlayer();
        }

        public void NextTurn()
        {
            SwitchPlayer();
        }

        public void SwitchPlayer()
        {
            var players = Players as List<IPlayer>;
            currentPlayerIndex = (currentPlayerIndex + 1) < players.Count ? currentPlayerIndex + 1 : 0;
            UpdateCurrentPlayer();
        }

        public void UpdateCurrentPlayer()
        {
            var players = Players as List<IPlayer>;
            CurrentPlayer = players[currentPlayerIndex];
        }

        public void AddPlayer(IPlayer player)
        {
            var players = Players as List<IPlayer>;
            players.Add(player);
        }

        public void Solve()
        {
            Resolver.PresolveSquares(Chessboard.Squares);
            Resolver.PresolvePieces(Chessboard.Pieces, MoveRegister);
        }

        public IPlayer GetPlayer(int id)
        {
            var players = Players as List<IPlayer>;
            return players.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
