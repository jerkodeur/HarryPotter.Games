namespace HarryPotter.Games.Core.Models.Force
{
    public class NeutreForce : AbstractForce
    {
        public static string Label { get; } = "Force Neutre";
        public NeutreForce(int index) : base(index, Label) { }
    }
}
