using JerkoLibs.Core.Common.Interfaces;

namespace HarryPotter.Games.Core.Commandes.GameMenu
{
    public class GameInfoCommand : ICommand
    {
        const string TITLE = "Harry Potter";
        const string SUBTITLE = "Un jeu épique !";

        public void Execute()
        {
            ConsoleLine.WriteLine($"{TITLE}, {SUBTITLE.Substring(0, SUBTITLE.Length - 2)}", ConsoleColor.Yellow);
        }
    }
}
