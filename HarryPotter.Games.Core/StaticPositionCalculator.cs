using HarryPotter.Games.Core.Models;

namespace HarryPotter.Games.Core
{
    public class StaticPositionCalculator : PositionCalculator
    {
        public StaticPositionCalculator(int x, int y) : base(x, y) { }
        public StaticPositionCalculator() : base() { }
    }
}
