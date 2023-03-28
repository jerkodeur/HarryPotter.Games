using System.Collections.Generic;
using JerkoLibs.Core.Console.Menu;

namespace HarryPotter.Games.Core
{
    public abstract class Force
    {
        public MenuItem item { get; private set; }
        public static string Question { get; } = "Avec quel coté de la force va tu commencer le jeu ?";

        public static readonly List<Force> ForceList = new List<Force>
        {
            new NeutreForce(),
            new LightForce(),
            new ObscurForce()
        };

        public Force() { }

        public Force(int id, string label)
        {
            item = new MenuItem(id, label);
        }

        private static Menu getMenu()
        {
            Menu forceMenu = new(Question);

            foreach (Force force in ForceList)
            {
                forceMenu.Items.Add(force.item);
            }

            return forceMenu;
        }

        public static Force GetPlayerSideForce()
        {
            int selectedForceId =  MenuHelper.GetMenuSelection(getMenu());

            return ForceList[selectedForceId];
        }

        public override string ToString()
        {
            return string.Format("MenuItem: {0}", item);
        }
    }
}
