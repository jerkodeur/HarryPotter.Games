using HarryPotter.Games.Core.Exceptions;
using HarryPotter.Games.Core.Models;
using JerkoLibs.Core.Common;
using JerkoLibs.Core.Common.Interfaces;
using JerkoLibs.Core.DataLayers.Interfaces;
using JerkoLibs.Core.DataLayers;
using JerkoLibs.Core.Date;

namespace HarryPotter.Games.Core.Commandes.GameMenu
{
    public class NewGameCommand : ICommand
    {
        #region Properties
        const int MIN_AGE = 12;
        Force force = new Force();
        Player? player;
        Ennemy ennemy = new Ennemy("Comte Doku");
        Grid2D gameGrid = new(new Position(0, 500), new Position(0, 300));
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
            player.Force = new LightForce();
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
            force.Selected?.item.DisplaySelectedItem();
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
        private Force GetPlayerForce()
        {
            return force.SetPlayerSideForce();
        }

        void PlayerActions()
        {
            ConsoleLine.WriteLine("\n");

            ConsoleLine.WriteLine(player.CurrentPosition.ToString(), ConsoleColor.Yellow);
            player.Move(new PlayerPosition(2, 4));
            player.Attack(ennemy, 20);
            ennemy.Attack(player, 50);
            player.Move(new RandomPositionCalculator(gameGrid.X, gameGrid.Y));
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
            IDataLayer<Grid2D> grid = new JsonDataLayer<Grid2D>(@"C:\Users\jerom\Documents\Dev\Tests", "grid", "json");
            grid.Write(gameGrid);

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
