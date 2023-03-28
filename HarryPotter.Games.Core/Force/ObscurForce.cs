namespace HarryPotter.Games.Core
{
    public class ObscurForce : Force
    {
        public new static string Question { get; } = "Force obscure";
        public ObscurForce() : base(2, Question) { }
    }
}
