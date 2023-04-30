using System.Reflection.Emit;
using JerkoLibs.Core.Console.Menu;

namespace HarryPotter.Games.Core.Models.Force
{
    public abstract class ForceItem: IForce
    {
        public abstract int Id { get; init; }
        public abstract string Label { get; init; }
        public MenuItem item { get; init; }

        public ForceItem(int id, string label): this(new MenuItem(id,label)) { }
        public ForceItem () {
            item = new MenuItem(Id, Label);
            ;
        }
        public ForceItem(MenuItem menuItem) => item = menuItem;
    }
}
