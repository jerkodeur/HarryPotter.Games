using HarryPotter.Games.Core.Models;
using HarryPotter.Games.Core.Models.Force;

namespace HarryPotter.Games.Core
{
    public class Ennemy : Character
    {
        public Ennemy(string name) : base(name) { }

        public override ForceItem Force { get; set; } = new ObscurForce();
    }
}
