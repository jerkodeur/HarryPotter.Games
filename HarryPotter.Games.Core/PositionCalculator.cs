using HarryPotter.Games.Core.Interfaces;
using HarryPotter.Games.Core.Models;
using JerkoLibs.Core.Common;

namespace HarryPotter.Games.Core
{
    public abstract class PositionCalculator : IPositionCalculator
    {
        public Position Default = new Position(0,100);

        public Position? X;
        public Position? Y;

        public PositionCalculator() { }

        public PositionCalculator(int x, int y) 
        { 
            Default = new Position(x,y);
        }

        public PositionCalculator(Position x, Position y)
        {
            X = x;
            Y = y;
        }

        public virtual PlayerPosition Compute()
        {
            return Compute(Default.Min, Default.Max);
        }

        public virtual PlayerPosition Compute(int x, int y)
        {
            return new (x, y);
        }
    }
}
