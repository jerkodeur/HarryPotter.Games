using HarryPotter.Games.Core.Models;
using JerkoLibs.Core.Common;

namespace HarryPotter.Games.Core
{
    public class RandomPositionCalculator : PositionCalculator
    {
        private readonly Random _random = new Random();

        

        public RandomPositionCalculator(int x, int y) : base(x, y) { }
        public RandomPositionCalculator(Position x, Position y) : base(x, y) { }

        public override PlayerPosition Compute()
        {
            if(X != null && Y != null)
            {
                return Compute(X, Y);
            }

            return base.Compute();
        }

        public override PlayerPosition Compute(int min, int max)
        {
            return new PlayerPosition()
            {
                X = _random.Next(min, max),
                Y = _random.Next(min, max)
            };
        }

        public PlayerPosition Compute(Position x, Position y)
        {
            return new PlayerPosition()
            {
                X = _random.Next(x.Min, x.Max),
                Y = _random.Next(y.Min, y.Max)
            };
        }
    }
}
