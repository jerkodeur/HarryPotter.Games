using HarryPotter.Games.Core.Settings;

namespace HarryPotter.Games.Core
{
    public class Game
    {
        public GameGrid grid { get; private set; } = new(0, 0);
        public Force Force { get; init; } = new();
        private GameSettings settings { get; set; } 

        public Game() {
            settings = new();
            Init(settings);
        }

        public Game(int rows, int cols)
        {
            settings = new(rows, cols);
            Init(settings);
        }

        internal void Init(GameSettings settings)
        {
            InitGrid(settings.Rows, settings.Columns);
        }

        public void InitGrid(int rows, int columns)
        {
            grid = new(rows, columns);
        }

    }
}
