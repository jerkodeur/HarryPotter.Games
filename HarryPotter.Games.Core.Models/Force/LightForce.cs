using JerkoLibs.Core.Console.Menu;

namespace HarryPotter.Games.Core.Models.Force
{
    public class LightForce: ForceItem
    {
        public override int Id { get; init; }  = 1;
        public override string Label { get; init; } = "Force lumineuse";

        public LightForce(int index)
        {
            item = new MenuItem(index, Label);
        }

        public LightForce ()
        {
            item = new MenuItem(Id, Label);
        }
    }
}
