using JerkoLibs.Core.DataLayers;
using System.Xml.Serialization;

namespace HarryPotter.Games.Core
{
    public class LightForce : Force
    {
        public new static string Question { get; } = "Avec quel coté de la force va tu commencer le jeu ?";

        public LightForce() : base(1, Question) { }
    }
}
