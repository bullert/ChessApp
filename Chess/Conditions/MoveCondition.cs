using Chess.Core;
using Chess.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Conditions
{
    public interface IMoveCondition : ICloneable
    {
        bool Verify(IMove move, IMoveRegister moveRegister);
    }

    [Serializable]
    public abstract class MoveCondition
    {
        public abstract bool Verify(IMove move, IMoveRegister moveRegister);

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
