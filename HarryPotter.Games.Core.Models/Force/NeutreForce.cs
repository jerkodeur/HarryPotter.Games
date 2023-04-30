using JerkoLibs.Core.Console.Menu;

namespace HarryPotter.Games.Core.Models.Force
{
    public class NeutreForce : ForceItem
    {
        public override int Id { get; init; } = 2;
        public override string Label { get; init; } = "Force Neutre";

        public NeutreForce(int index) 
        {
            item = new MenuItem(index, Label);
        }

        public NeutreForce ()
        {
            item = new MenuItem(Id, Label);
        }
    }
}
