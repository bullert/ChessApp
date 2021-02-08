using Chess.Board;
using Chess.Conditions;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Moves
{
    [Serializable]
    class EntryDoubleForwardMove : ContinuousMove, IContinuousMove
    {
        public EntryDoubleForwardMove(IPiece piece) : 
            base(piece, 
                new Position(0, 2), 
                new List<IPosition>()
                { 
                    new Position(0, 1)
                })
        {
            Conditions = new List<IMoveCondition>()
            {
                new FirstMoveCondition(),
                new NoCaptureMoveCondition(),
                new FreePathMoveCondition()
            };
        }
    }
}
