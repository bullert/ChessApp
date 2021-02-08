using Chess.Core;
using Chess.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Conditions
{
    public interface IContinuousMoveCondition : IMoveCondition
    {
        public bool Verify(IContinuousMove move, IMoveRegister moveRegister);
    }

    [Serializable]
    public abstract class ContinuousMoveCondition : IContinuousMoveCondition
    {
        public abstract bool Verify(IContinuousMove move, IMoveRegister moveRegister);

        bool IMoveCondition.Verify(IMove move, IMoveRegister moveRegister)
        {
            return Verify(move as IContinuousMove, moveRegister);
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
