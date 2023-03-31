using JerkoLibs.Core.Common.Interfaces;

namespace HarryPotter.Games.Core.Commandes.GameMenu
{
    public class LoadGameCommand : ICommand
    {
        public void Execute()
        {
            ConsoleConfirmationLine.WriteLine("Chargement de la partie ...");
        }
    }
}
