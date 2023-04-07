using JerkoLibs.Core.Common.Interfaces;

namespace HarryPotter.Games.Core.Commandes.GameMenu
{
    public class DisplayCreditCommand : ICommand
    {
        public void Execute()
        {
            ConsoleLine.WriteLine("=======================================", ConsoleColor.Green);
            ConsoleLine.WriteLine("Jérôme Potié alias Jéjé. Copyright 2023", ConsoleColor.Yellow);
            ConsoleLine.WriteLine("=======================================", ConsoleColor.Green);
        }
    }
}
