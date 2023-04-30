using HarryPotter.Games.Core.Layers;
using JerkoLibs.Core.Common.Interfaces;

namespace HarryPotter.Games.Core.Commandes.GameMenu
{
    public class SaveGameCommand: ICommand
    {
        public void Execute()
        {
            ConsoleLine.WriteLine("Save the game...");
        }

        public void Execute (Game game)
        {
            GameDbDataLayer gameDataLayer = new();
            gameDataLayer.Write();
            game.Id = gameDataLayer.InsertedId;
            new GameDbSettingsDataLayer().Write(game);
            foreach(Ennemy ennemy in game.Ennemies)
            {
                new EnnemyDbDataLayer().Write(game, ennemy);
            }
            new PlayerDbDataLayer().Write(game, game.Player);
        }
    }
}
