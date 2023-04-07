namespace HarryPotter.Games.Core.Settings
{
    internal class GameSettings
    {
        private const int DEFAULT_GRID_ROWS = 20;
        private const int DEFAULT_GRID_COLS = 20;

        public int Rows { get; private set; } = DEFAULT_GRID_ROWS;
        public int Columns { get; private set; } = DEFAULT_GRID_COLS;

        public GameSettings() { }

        public GameSettings(int rows, int columns) 
        {
            Rows = rows;
            Columns = columns;
        }

    }
}
