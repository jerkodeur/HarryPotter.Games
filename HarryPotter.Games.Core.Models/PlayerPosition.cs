namespace HarryPotter.Games.Core.Models
{
    public class PlayerPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PlayerPosition(): this(1,1) { }
        public PlayerPosition(int x): this(x,1) { }
        public PlayerPosition(int x, int y) { X = x; Y = y; }

        public override string ToString()
        {
            return String.Format("X: {0}, Y: {1}", X, Y);
        }
    }
}
