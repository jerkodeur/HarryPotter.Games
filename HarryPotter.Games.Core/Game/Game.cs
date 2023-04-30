using HarryPotter.Games.Core.Models;
using HarryPotter.Games.Core.Settings;

namespace HarryPotter.Games.Core
{
    public class Game
    {
        #region Properties
        public int Id { get; set; }
        public GameGrid grid { get; private set; } = new(0, 0);
        public Force Force { get; init; } = new();
        public Player Player { get; set; } = new Player();
        public List<Ennemy> Ennemies { get; private set; } = new();
        private GameSettings settings { get; set; } = new(); 
        #endregion
        #region Constructors
        private Game() { }

        public Game (int id, int rows, int cols) : this(rows, cols)
        {
            Id = id;
        }

        public Game (int rows, int cols) : this(rows, cols, new Player()) { }

        public Game(int rows, int cols, Player player)
        {
            Player = player;
            settings = new GameSettings(rows, cols);
            Init();
        }
        #endregion
        #region Public Methods
        
        public void NewEnnemy(Ennemy ennemy)
        {
            Ennemies.Add(ennemy);
            ennemy.IsDead += CharacterIsDead;
        }
        public void SaveGame()
        {
            ConsoleConfirmationLine.WriteLine("Game saved");
        }

        #endregion
        #region Private Methods

        private void InitGrid(int rows, int columns)
        {
            grid = new(rows, columns);
        }

        /// <summary>
        /// Event triggered when a Character is dead
        /// </summary>
        /// <param name="character"></param>
        private void CharacterIsDead(Character character)
        {
            if (character == Player)
            {
                EndGame();
            }
            else
            {
                ConsoleLine.WriteLine($"Le personnage {character.Name} est mort suite à ses blessures...", ConsoleColor.Cyan);
            }
        }

        /// <summary>
        /// Event triggered when the player is dead
        /// </summary>
        private void EndGame()
        {
            ConsoleLine.WriteLine($"Le joueur {Player.Name} est mort ! Fin de la partie...", ConsoleColor.Cyan);
        }

        /// <summary>
        /// Events Subscriptions
        /// </summary>
        private void subscriptions()
        {
            Player.IsDead += CharacterIsDead;
        }

        #endregion
        #region Internal Methods

        internal void Init()
        {
            InitGrid(settings.Grid.Rows, settings.Grid.Cols);
            subscriptions();
        }

        #endregion
        #region Destructor
        ~Game()
        {
            Player.IsDead -= CharacterIsDead;
            foreach(Ennemy ennemy in Ennemies)
            {
                ennemy.IsDead -= CharacterIsDead;
            }
        } 
        #endregion

    }
}
