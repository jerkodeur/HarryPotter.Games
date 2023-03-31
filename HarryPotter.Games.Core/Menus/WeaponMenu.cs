using JerkoLibs.Core.Console.Menu;

namespace HarryPotter.Games.Core.Menus
{
    public class WeaponMenu : GenericMenu<MenuItem>
    {
        protected new string title = "Avec quel arme souhaitez-vous commencez la partie ?";

        protected override Menu<MenuItem> GetIniatializedMenu()
        {
            Menu<MenuItem> menu = new(title);
            menu.Add(new(0, "gun"));
            menu.Add(new(1, "bow"));
            menu.Add(new(2, "crossbow"));
            menu.Add(new(3, "machinegun"));
            menu.Add(new(4, "axe"));

            return menu;
        }
    }
}
