using JerkoLibs.Core.Common.Interfaces;

namespace HarryPotter.Games.Core.Commandes.GameMenu
{
    public class LoadGameCommand : ICommand
    {
        public void Execute()
        {
            var cellA = new GameCell(1, 1);
            var cellB = new GameCell(1, 1);

            ConsoleLine.WriteLine(String.Format("{0}", cellA == cellB));
            ConsoleConfirmationLine.WriteLine("Chargement de la partie ...");
        }
    }
}
