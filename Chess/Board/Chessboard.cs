﻿using Chess.Core;
using Chess.Enums;
using Chess.Pieces;
using Chess.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Board
{
    public interface IChessboardDependency
    {
        IChessboard Chessboard { get; }
    }

    public interface IChessboard
    {
        List<ISquare> Squares { get; }

        List<IPiece> Pieces { get; set; }

        List<IPiece> CapturedPieces { get; set; }

        Dictionary<Color, IMatrix> ColorMatrixDict { get; set; }

        int Size { get; }

        int Length { get; }

        void Initialize();

        void SetPiece(IPiece piece, IPosition square);

        ISquare GetSquare(IPosition position);

        bool IsPositionOutOfBoard(IPosition position);

        ISquare GetRelativeSquare(ISquare square, IPosition offset);

        IPosition GetRelativePosition(Color color, IPosition position);

        bool HasSquare(IPosition position);

        List<IPiece> GetPieces(Type type, Color color);
    }

    [Serializable]
    public class Chessboard : IChessboard
    {
        public Chessboard(IMoveRegister moveRegister, int length = 8)
        {
            Squares = new List<ISquare>();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Squares.Add(new Square(new Position(i, j), this));
                }
            }

            Length = length;
            Size = Squares.Count;

            ColorMatrixDict = new Dictionary<Color, IMatrix>()
            {
                { Color.WHITE, new Matrix(new Position(1, 1)) },
                { Color.BLACK, new Matrix(new Position(-1,-1)) }
            };

            Pieces = new List<IPiece>();
            CapturedPieces = new List<IPiece>();
        }

        public Chessboard(List<ISquare> squares, List<IPiece> pieces, List<IPiece> capturedPieces, Dictionary<Color, IMatrix> colorMatrixDict, int size, int length)
        {
            Squares = squares;
            Pieces = pieces;
            CapturedPieces = capturedPieces;
            ColorMatrixDict = colorMatrixDict;
            Size = size;
            Length = length;
        }

        public List<ISquare> Squares { get; }

        public List<IPiece> Pieces { get; set; }

        public List<IPiece> CapturedPieces { get; set; }

        public Dictionary<Color, IMatrix> ColorMatrixDict { get; set; }
        
        public int Size { get; }

        public int Length { get; }

        public void Initialize()
        {
            for (int i = 0; i < Pieces.Count; i++)
            {
                Pieces[i].Initialize();
            }
        }

        public void SetPiece(IPiece piece, IPosition position)
        {
            Pieces.Add(piece);
            piece.Claim(GetSquare(position));
        }

        public ISquare GetSquare(IPosition position)
        {
            var square = Squares.Find(
                    x => (x.Position.Rank == position.Rank && x.Position.File == position.File)
                );

            if (square == null)
                throw new SquareNullException(position);

            return square;
        }

        public bool IsPositionOutOfBoard(IPosition position)
        {
            if (position.File < 0 || position.File > Length - 1 ||
                position.Rank < 0 || position.Rank > Length - 1)
                return true;
            return false;
        }

        public ISquare GetRelativeSquare(ISquare square, IPosition offset)
        {
            return GetSquare(Position.Add(square.Position, offset));
        }

        public IPosition GetRelativePosition(Color color, IPosition position)
        {
            return ColorMatrixDict[color].Transform(position);
        }

        public bool HasSquare(IPosition position)
        {
            return GetSquare(position) != null;
        }

        public List<IPiece> GetPieces(Type type, Color color)
        {
            return Pieces.FindAll(
                    x => x.GetType() == type && x.Color == color
                );
        }
    }
}
