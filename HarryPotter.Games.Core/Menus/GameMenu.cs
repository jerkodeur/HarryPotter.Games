using HarryPotter.Games.Core.Commandes.Game;
using HarryPotter.Games.Core.Commandes.GameMenu;
using JerkoLibs.Core.Console.Menu;

namespace HarryPotter.Games.Core.Menus
{
    public class GameMenu : GenericMenu<MenuItem>
    {
        protected new string title = "Quelle action souhaitez-vous réaliser ?";
        public GameMenu(): base()
        {
            
        }

        protected override Menu<MenuItem> GetIniatializedMenu()
        {
            Menu<MenuItem> menu = new(title);
            menu.Add(new MenuItem(++id, "afficher les infos du jeu", new GameInfoCommand()));
            menu.Add(new MenuItem(++id, "nouvelle partie", new NewGameCommand()));
            menu.Add(new MenuItem(++id, "charger partie", new LoadGameCommand()));
            menu.Add(new MenuItem(++id, "crédits", new DisplayCreditCommand()));
            menu.Add(new MenuItem(++id, "quitter", new ExitGameCommand()));

            return menu;
        }

        public override MenuItem PromptUserToSelectOption()
        {
            MenuItem exitOption = menu.Items.Where(item => item.Label == "quitter").Single();
            MenuItem selectedItem = base.PromptUserToSelectOption();

            while (base.PromptUserToSelectOption() != exitOption)
            {
                base.PromptUserToSelectOption();
            }

            return selectedItem;
        }
    }
}
