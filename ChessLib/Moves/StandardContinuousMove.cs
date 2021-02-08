using Chess.Board;
using Chess.Conditions;
using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Moves
{
    [Serializable]
    class StandardContinuousMove : ContinuousMove, IContinuousMove
    {
        public StandardContinuousMove(IPiece piece, IPosition pattern, List<IPosition> path) : base(piece, pattern, path)
        {
            //Conditions = new List<IMoveCondition>
            //{
            //    new 
            //};
        }
    }
}
