namespace HarryPotter.Games.Core
{
    public class LightForce : Force
    {
        public new static string Question { get; } = "Force lumineuse";

        public LightForce() : base(1, Question) { }
    }
}
