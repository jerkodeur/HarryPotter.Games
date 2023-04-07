namespace HarryPotter.Games.Core.Models.Force
{
    public class LightForce : AbstractForce
    {
        public static string Label { get; } = "Force lumineuse";

        public LightForce(int index) : base(index, Label) { }
    }
}
