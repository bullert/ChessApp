using Chess.Enums;
using Chess.Moves;
using Chess.Pieces;
using Chess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Core
{
    public interface IMoveRegister
    {
        int Count { get; }

        void Register(IMove move);

        List<IMove> GetAllMoves();

        List<IMove> GetAllMovesOf(IPiece piece);

        List<IMove> GetAllMovesOf(Color color);

        IMove GetMoveOfAt(IPiece piece, int index);

        IMove GetMoveOfAt(Color color, int index);
    }

    public class MoveRegister : IMoveRegister
    {
        private List<IMove> moves;

        public MoveRegister()
        {
            moves = new List<IMove>();
        }

        public int Count => moves.Count;

        public void Register(IMove move)
        {
            moves.Add(move);
        }

        public List<IMove> GetAllMoves()
        {
            return moves;
        }

        public List<IMove> GetAllMovesOf(IPiece piece)
        {
            var list = new List<IMove>();
            for (int i = 0; i < Count; i++)
            {
                var move = moves[i];
                if (move.Piece == piece)
                    list.Add(move);
            }
            return list;
        }

        public List<IMove> GetAllMovesOf(Color color)
        {
            var list = new List<IMove>();
            for (int i = 0; i < Count; i++)
            {
                var move = moves[i];
                if (move.Piece.Color == color)
                    list.Add(move);
            }
            return list;
        }

        public IMove GetMoveOfAt(IPiece piece, int index)
        {
            var list = GetAllMovesOf(piece);
            if (index < 0)
                index = list.Count + index;
            return index >= 0 && index < list.Count ? list[index] : null;
        }

        public IMove GetMoveOfAt(Color color, int index)
        {
            var list = GetAllMovesOf(color);
            if (index < 0)
                index = list.Count + index;
            return index >= 0 && index < list.Count ? list[index] : null;
        }
    }
}
