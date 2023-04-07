using JerkoLibs.Core.Console.Menu;

namespace HarryPotter.Games.Core.Models.Force
{
    public abstract class AbstractForce: IForce
    {
        public MenuItem item { get; init; }
        public string Question { get; init; } = String.Empty;

        public AbstractForce(int id, string label): this(new MenuItem(id,label)) { }
        public AbstractForce(MenuItem menuItem) => item = menuItem;
    }
}
