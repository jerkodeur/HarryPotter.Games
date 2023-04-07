using HarryPotter.Games.Core.Exceptions;
using JerkoLibs.Core.Common;
using JerkoLibs.Core.Common.Interfaces;
using JerkoLibs.Core.DataLayers.Interfaces;
using JerkoLibs.Core.DataLayers;
using JerkoLibs.Core.Date;
using HarryPotter.Games.Core.Interfaces;

namespace HarryPotter.Games.Core.Commandes.GameMenu
{
    public class NewGameCommand : ICommand
    {
        #region Properties
        private Game game = new(20,20);
        const int MIN_AGE = 12;
        private Player? player;
        private Ennemy ennemy = new Ennemy("Comte Doku");
        #endregion

        #region MainMethod
        public void Execute()
        {
            QuickActions();
            //Actions();
            //PlayerActions();
            //GetClassInfoInJson();
        }
        public void QuickActions()
        {
            player = new Player("Jéjé", DateOnly.Parse("16/12/1977"));
            player.Force = game.Force.SetPlayerSideForce();
            game.grid.AddCharacterToPosition(new Position(1, 2), player);
            game.grid.AddCharacterToPosition(new Position(1, 2), ennemy);

            var busyCells = game.grid.GetBusyCells();
            var emptyCells = game.grid.GetEmptyCells();
            var charactersOnCell = game.grid.GetCharactersOnCell(new Position(1, 2));
            var characterPosition = game.grid.GetCharacterPositionOnGrid(player);
            var isCombatPossible = game.grid.IsFightPossibleOnCell(player, new Position(1, 2));
            var isCellBusy = game.grid.IsCellBusy(new Position(1, 2));
            var isPlayerOnCell = game.grid.IsCharacterOnCell(player, new Position(1, 1));

        }

        public void Actions()
        {
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

            player.Force = GetPlayerForce();
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
        private IForce GetPlayerForce()
        {
            return game.Force.SetPlayerSideForce();
        }

        void PlayerActions()
        {
            ConsoleLine.WriteLine("\n");

            ConsoleLine.WriteLine(player.CurrentPosition.ToString(), ConsoleColor.Yellow);
            player.Move(new Position(2, 4));
            player.Attack(ennemy, 20);
            ennemy.Attack(player, 50);
            player.Move(new RandomPositionCalculator(game.grid.Rows, game.grid.Cols));
            player.Move(new StaticPositionCalculator());
            ConsoleLine.WriteLine(player.CurrentPosition.ToString(), ConsoleColor.Yellow);
        }

        private void GetClassInfoInXml()
        {
            IDataLayer<Ennemy> saveEnnemy = new XmlDataLayer<Ennemy>(@"C:\Users\jerom\Documents\Dev\Tests", "player", "xml");
            saveEnnemy.Write(ennemy);
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
            //var readFile = grid.Read(typeof(Grid2D));
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
