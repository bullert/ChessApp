using Chess.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Utils.Exceptions
{
    [Serializable]
    public class SquareNullException : Exception
    {
        public SquareNullException(string message = "Square is out of board.") : 
            base(message)
        {
            
        }

        public SquareNullException(IPosition position) : 
            base(string.Format("Square at position {0} is out of board.", position))
        {

        }
    }
}
