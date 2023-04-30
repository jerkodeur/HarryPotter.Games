namespace LinqTraining
{
    internal class MagicWand
    {
        public int Id { get; set; }
        public string Label { get; set; } = String.Empty;

        public MagicWand(int id, string label)
        {
            Id = id;
            Label = label;
        }
    }
}
