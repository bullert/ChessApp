﻿using Chess;
using Chess.Board;
using Chess.Core;
using Chess.Enums;
using Chess.Moves;
using System;
using System.Collections.Generic;

namespace Chess.Pieces
{
    public interface IPiece : IChessboardDependency
    {
        ISquare Square { get; set; }

        Color Color { get; set; }

        List<IMove> Moves { get; set; }

        List<IMove> LegalMoves { get; set; }

        void Initialize();

        void Claim(ISquare square);

        void Leave();

        void Presolve(IMoveRegister moveRegister);

        bool IsEnemyOf(IPiece piece);
    }

    [Serializable]
    public abstract class Piece : IPiece, IChessboardDependency
    {
        protected ISquare square;
        protected Color color;

        public Piece(Color color)
        {
            Color = color;
            Moves = new List<IMove>();
            LegalMoves = new List<IMove>();
        }

        public Piece(Color color, ISquare square, IChessboard chessboard, List<IMove> moves, List<IMove> legalMoves)
        {
            Color = color;
            Square = square;
            Chessboard = chessboard;
            Moves = moves;
            LegalMoves = legalMoves;
        }

        public List<IMove> Moves { get; set; }

        public List<IMove> LegalMoves { get; set; }

        public ISquare Square { get; set; }

        public Color Color { get; set; }

        public IChessboard Chessboard { get; private set; }

        public void Initialize()
        {
            for (int i = 0; i < Moves.Count; i++)
            {
                Moves[i].Initialize();
            }
        }

        public void Claim(ISquare square)
        {
            Square = square;
            Square.OccupiedBy = this;
            Square.IsEmpty = false;
            if (Chessboard == null)
                Chessboard = Square.Chessboard;
        }

        public void Leave()
        {
            if (Square != null)
            {
                Square.OccupiedBy = null;
                Square.IsEmpty = true;
                Square = null;
            }
        }

        public void Presolve(IMoveRegister moveRegister)
        {
            LegalMoves.Clear();
            for (int i = 0; i < Moves.Count; i++)
            {
                Moves[i].Presolve(moveRegister);
            }
        }

        public bool IsEnemyOf(IPiece piece)
        {
            return Color != piece.Color;
        }
    }
}
