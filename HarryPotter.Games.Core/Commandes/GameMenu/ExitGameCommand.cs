using JerkoLibs.Core.Common.Interfaces;

namespace HarryPotter.Games.Core.Commandes.GameMenu
{
    public class ExitGameCommand : ICommand
    {
        public void Execute()
        {
            ConsoleErrorLine.WriteLine("A bientôt sur le jeu !");
            Environment.Exit(-1);
        }
    }
}
