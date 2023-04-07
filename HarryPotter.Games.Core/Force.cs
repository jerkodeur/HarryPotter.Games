using HarryPotter.Games.Core.Interfaces;
using HarryPotter.Games.Core.Models.Force;
using JerkoLibs.Core.Console.Menu;
using System.Xml.Serialization;

namespace HarryPotter.Games.Core
{
    [XmlInclude(typeof(LightForce))]
    [XmlInclude(typeof(NeutreForce))]
    [XmlInclude(typeof(ObscurForce))]
    public class Force
    {
        private string Question { get; } = "Avec quel coté de la force va tu commencer le jeu ?";

        private Menu<MenuItem> ForceMenu { get; set; }
        public List<AbstractForce> Forces = new List<AbstractForce>();

        #region Constructors

        public Force() 
        { 
            InitializeForceList();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            int index = 0;
            ForceMenu = new Menu<MenuItem>(Question);

            ForceMenu.Add(new LightForce(++index).item);
            ForceMenu.Add(new NeutreForce(++index).item);
            ForceMenu.Add(new ObscurForce(++index).item);
        }
        private void InitializeForceList()
        {
            int index = 0;

            Forces = new List<AbstractForce>
            {
                new LightForce(++index),
                new NeutreForce(++index),
                new ObscurForce(++index)
            };
        }

        public AbstractForce SetPlayerSideForce()
        {
            MenuItem selection = ForceMenu.PromptUserToSelectOption();

            return Forces[selection.Id - 1];
        } 
        #endregion
    }
}
