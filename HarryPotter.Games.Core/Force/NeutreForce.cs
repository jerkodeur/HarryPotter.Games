namespace HarryPotter.Games.Core
{
    public class NeutreForce : Force
    {
        public new static string Question { get; } = "Force Neutre";
        public NeutreForce() : base(0, Question) { }
    }
}
