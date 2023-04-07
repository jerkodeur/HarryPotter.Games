namespace HarryPotter.Games.Core.Models.Force
{
    public class ObscurForce : AbstractForce
    {
        public static string Label { get; } = "Force obscure";
        public ObscurForce(int index) : base(index, Label) { }
    }
}
