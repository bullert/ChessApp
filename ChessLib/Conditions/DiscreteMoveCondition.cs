using Chess.Core;
using Chess.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Conditions
{
    public interface IDiscreteMoveCondition : IMoveCondition
    {
        public bool Verify(IDiscreteMove move, IMoveRegister moveRegister);
    }

    [Serializable]
    public abstract class DiscreteMoveCondition : IDiscreteMoveCondition
    {
        public abstract bool Verify(IDiscreteMove move, IMoveRegister moveRegister);

        bool IMoveCondition.Verify(IMove move, IMoveRegister moveRegister)
        {
            return Verify(move as IDiscreteMove, moveRegister);
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
