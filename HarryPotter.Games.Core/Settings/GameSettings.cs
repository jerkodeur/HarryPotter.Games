namespace HarryPotter.Games.Core.Settings
{
    public class GameSettings
    {
        public int Id { get; private set; }
        private const int DEFAULT_GRID_ROWS = 20;
        private const int DEFAULT_GRID_COLS = 20;

        public Grid Grid { get; private set; }

        public GameSettings(): this(DEFAULT_GRID_ROWS, DEFAULT_GRID_COLS) { }

        public GameSettings(int rows, int columns) 
        {
            Grid = new Grid(rows, columns);
        }
    }
}
