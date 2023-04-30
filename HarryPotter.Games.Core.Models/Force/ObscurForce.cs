using JerkoLibs.Core.Console.Menu;

namespace HarryPotter.Games.Core.Models.Force
{
    public class ObscurForce : ForceItem
    {
        public override string Label { get; init; } = "Force obscure";
        public override int Id { get; init; } = 3;

        public ObscurForce (int index)
        {
            item = new MenuItem(index, Label);
        }

        public ObscurForce ()
        {
            item = new MenuItem(Id, Label);
        }
    }
}
