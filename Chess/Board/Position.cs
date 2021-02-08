using System;

namespace Chess.Board
{
    public interface IPosition : ICloneable
    {
        int Rank { get; set; }

        int File { get; set; }

        IPosition Copy(IPosition p);

        IPosition Add(IPosition p0, IPosition p1);

        IPosition Subtract(IPosition p0, IPosition p1);

        IPosition Scale(IPosition p, int s);

        string ToAlgebraicNotation();

        string ToString();
    }

    [Serializable]
    public class Position : IPosition
    {
        public Position(int file = 0, int rank = 0)
        {
            File = file;
            Rank = rank;
        }

        public int Rank { get; set; }

        public int File { get; set; }

        public string RankLabel { get => (Rank + 1).ToString(); }

        public string FileLabel { get => ((char)(File + 97)).ToString(); }

        public static IPosition Copy(IPosition p)
        {
            return new Position(p.File, p.Rank);
        }

        IPosition IPosition.Copy(IPosition p)
        {
            return Position.Copy(p);
        }

        public static IPosition Add(IPosition p0, IPosition p1)
        {
            return new Position(p0.File + p1.File, p0.Rank + p1.Rank);
        }

        IPosition IPosition.Add(IPosition p0, IPosition p1)
        {
            return Position.Add(p0, p1);
        }

        public static IPosition Subtract(IPosition p0, IPosition p1)
        {
            return new Position(p0.File - p1.File, p0.Rank - p1.Rank);
        }

        IPosition IPosition.Subtract(IPosition p0, IPosition p1)
        {
            return Position.Subtract(p0, p1);
        }

        public static IPosition Scale(IPosition p, int s)
        {
            return new Position(p.File * s, p.Rank * s);
        }

        IPosition IPosition.Scale(IPosition p, int s)
        {
            return Position.Scale(p, s);
        }

        public string ToAlgebraicNotation()
        {
            return string.Format("{0}{1}", FileLabel, RankLabel);
        }

        public override string ToString()
        {
            return string.Format("Position: {{ File: {0}, Rank: {1} }}", File, Rank);
        }

        public static bool operator ==(Position p0, Position p1)
        {
            return p0.File == p1.File && p0.Rank == p1.Rank;
        }

        public static bool operator !=(Position p0, Position p1)
        {
            return !(p0 == p1);
        }

        public override bool Equals(object o)
        {
            if (!(o is Position)) return false;

            var p = o as Position;
            return File == p.File && Rank == p.Rank;
        }

        public override int GetHashCode()
        {
            return File ^ Rank;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
