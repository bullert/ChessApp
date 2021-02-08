using Chess.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Core
{
    public interface IMatrix : ICloneable
    {
        public IPosition Indicator { get; set; }

        public IPosition Transform(IPosition position);
    }

    [Serializable]
    public class Matrix : IMatrix
    {
        public Matrix(IPosition indicator)
        {
            Indicator = indicator;
        }

        public IPosition Indicator { get; set; }

        public IPosition Transform(IPosition position)
        {
            return new Position(
                    (int)(position.File * Indicator.File),
                    (int)(position.Rank * Indicator.Rank)
                );
        }

        public object Clone()
        {
            //return this.MemberwiseClone();
            return new Matrix(Indicator);
        }
    }
}
