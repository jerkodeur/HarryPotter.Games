using JerkoLibs.Core.Console.Menu;
using System.Xml.Serialization;

namespace HarryPotter.Games.Core
{
    [XmlInclude(typeof(LightForce))]
    [XmlInclude(typeof(NeutreForce))]
    [XmlInclude(typeof(ObscurForce))]
    public class Force
    {
        public MenuItem item { get; init; }
        private string Question { get; } = "Avec quel coté de la force va tu commencer le jeu ?";

        private Menu<MenuItem> ForceMenu { get; set; }
        public List<Force> Forces = new List<Force>();
        public Force ? Selected { get; set; }

        #region Constructors

        public Force() 
        { 
            InitializeMenu();
            InitializeForceList();
        }

        public Force(int id, string label) :base()
        {
            item = new MenuItem(id, label);
        }

        private void InitializeMenu()
        {
            ForceMenu = new Menu<MenuItem>(Question);
            ForceMenu.Add(new NeutreForce().item);
            ForceMenu.Add(new LightForce().item);
            ForceMenu.Add(new ObscurForce().item);
        }
        private void InitializeForceList()
        {
            Forces = new List<Force>
            {
                new NeutreForce(),
                new LightForce(),
                new ObscurForce()
            };
        }

        public Force SetPlayerSideForce()
        {
            MenuItem itemSelected = ForceMenu.PromptUserToSelectOption();
            Selected = Forces[itemSelected.Id];

            return Selected;
        } 
        #endregion

        public override string ToString()
        {
            return string.Format("MenuItem: {0}", item);
        }
    }
}
