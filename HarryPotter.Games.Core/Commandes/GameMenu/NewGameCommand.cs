using HarryPotter.Games.Core.Exceptions;
using JerkoLibs.Core.Common.Interfaces;
using JerkoLibs.Core.DataLayers.Interfaces;
using JerkoLibs.Core.DataLayers;
using JerkoLibs.Core.Date;

namespace HarryPotter.Games.Core.Commandes.GameMenu
{
    public class NewGameCommand : ICommand
    {
        #region Properties
        private Game? game;
        const int MIN_AGE = 12;
        #endregion

        #region MainMethod
        public void Execute()
        {
            InitializeGame();
            QuickActions();
            //Actions();
            PlayerActions();
            //GetClassInfoInJson();
        }
        public void QuickActions()
        {
            
            game.grid.AddCharacterToPosition(new Position(1, 2), game.Player);
            game.grid.AddCharacterToPosition(new Position(1, 2), game.Ennemies[0]);

            var busyCells = game.grid.GetBusyCells();
            var emptyCells = game.grid.GetEmptyCells();
            var charactersOnCell = game.grid.GetCharactersOnCell(new Position(1, 2));
            var characterPosition = game.grid.GetCharacterPositionOnGrid(game.Player);
            var isCombatPossible = game.grid.IsFightPossibleOnCell(game.Player, new Position(1, 2));
            var isCellBusy = game.grid.IsCellBusy(new Position(1, 2));
            var isPlayerOnCell = game.grid.IsCharacterOnCell(game.Player, new Position(1, 1));

        }

        public void InitializeGame()
        {
            Player player = new Player("Jéjé", DateOnly.Parse("16/12/1977"));
            //Player player = GetFullPlayerInfos();
            game = new(20, 20, player);            
            player.Force = game.Force.SetPlayerSideForce();
            game.NewEnnemy(new("Comte Doku"));
        }

        public Player GetFullPlayerInfos()
        {
            Player player = new();
            ConsoleConfirmationLine.WriteLine("Démarrage de la partie ...");
            string playerName = GetPlayerName();
            ConsoleConfirmationLine.WriteLine($"Bienvenue {playerName}");

            DateOnly birthday = GetPlayerBirthday();
            int age = DateCalculators.getPlayerAge(birthday);


            try
            {
                if (hasTheRequiredAge(age))
                {
                    ConsoleConfirmationLine.WriteLine($"Tu as donc {age} ans! Tu peux jouer à ce jeu!!!");
                    player = new Player(playerName, birthday);
                }
                else
                {
                    throw new AgeNotValidException();
                }
            }
            catch (AgeNotValidException ex)
            {
                ConsoleErrorLine.WriteLine(ex.Message);
            }

            return player;
        }
        #endregion

        #region Execute Methods
        private string GetPlayerName()
        {
            return CoreConsole.GetUserInput("Quel est ton nom ?");
        }

        private DateOnly GetPlayerBirthday()
        {
            string inputBirthday = CoreConsole.GetUserInput("Quel est ta date de naissance ? (jj/mm/aaaa)");
            DateOnly playerBirthday;

            if (!DateOnly.TryParseExact(inputBirthday, "d/M/yyyy", out playerBirthday))
            {
                ConsoleErrorLine.WriteLine("Le format de la date de naissance n'est pas au bon format, veuillez recommencer.");
                return GetPlayerBirthday();
            }

            return playerBirthday;
        }

        void PlayerActions()
        {
            ConsoleLine.WriteLine("\n");
            ConsoleLine.WriteLine(game.Player.CurrentPosition.ToString(), ConsoleColor.Yellow);
            game.Player.Move(new RandomPositionCalculator(game.grid.Rows, game.grid.Cols));
            game.Player.Attack(game.Ennemies[0], 100);
            game.Ennemies[0].Attack(game.Player, 50);
            game.Ennemies[0].Attack(game.Player, 60);
        }

        private void GetClassInfoInXml()
        {
            IDataLayer<Ennemy> saveEnnemy = new XmlDataLayer<Ennemy>(@"C:\Users\jerom\Documents\Dev\Tests", "player", "xml");
            saveEnnemy.Write(game.Ennemies[0]);
            var @object = saveEnnemy.Read(typeof(Ennemy));
            ConsoleLine.WriteLine(@object.ToString(), ConsoleColor.Green);

            //TODO See how don't serialize some class properties (ex interfaces)
            //IDataLayer<List<Force>> forces = new DataLayerSerialization<List<Force>>(@"C:\Users\jerom\Documents\Dev\Testsn", "force", "xml");
            //forces.Write(Force.ForceList);
        }

        private void GetClassInfoInJson()
        {
            IDataLayer<GameGrid> grid = new JsonDataLayer<GameGrid>(@"C:\Users\jerom\Documents\Dev\Tests", "grid", "json");
            grid.Write(game.grid);

            //TODO See why an error occured 
            //var readFile = Grid.Read(typeof(Grid2D));
            //ConsoleLine.WriteLine(readFile.ToString(), ConsoleColor.Green);

            //IDataLayer<List<Force>> forces = new DataLayerSerialization<List<Force>>(@"C:\Users\jerom\Documents\Dev\Testsn", "force", "json");
            //forces.Write(Force.ForceList);
        }
        #endregion

        private bool hasTheRequiredAge(int age)
        {
            return age.CompareTo(MIN_AGE) >= 0;
        }
    }
}
