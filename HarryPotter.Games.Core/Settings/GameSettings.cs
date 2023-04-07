namespace HarryPotter.Games.Core.Settings
{
    internal class GameSettings
    {
        private const int DEFAULT_GRID_ROWS = 20;
        private const int DEFAULT_GRID_COLS = 20;

        public Grid Grid { get; set; }

        public GameSettings(): this(DEFAULT_GRID_ROWS, DEFAULT_GRID_COLS) { }

        public GameSettings(int rows, int columns) 
        {
            Grid = new Grid(rows, columns);
        }

    }
}
