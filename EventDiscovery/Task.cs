namespace EventDiscovery
{
    internal class Task
    {
        public int Id { get; set; }
        public float Duration { get; set; }
        public string Label { get; set; } = String.Empty;

        public override string ToString()
        {
            return String.Format("Numéro {0}: {1}", Id, Label);
        }
    }
}
