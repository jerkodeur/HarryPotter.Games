namespace LinqTraining
{
    internal sealed class Wizard
    {
        private const int LIFEPOINTS = 100;
        public string Name { get; set; } = String.Empty;
        public int LifePoints { get; set; } = LIFEPOINTS;
        public bool IsDark { get; set; } = false;
        public int WandId { get; set; }
        public MagicWand? MagicWand { get; set; }

        #region Constructors
        public Wizard() { }
        public Wizard(string name) : this(name, LIFEPOINTS) { }
        public Wizard(string name, int lifePoints) : this(name, lifePoints, false) { }
        public Wizard(string name, bool isDark) : this(name, LIFEPOINTS, isDark) { }
        public Wizard(string name, int lifePoints, bool isDark) : this(name,lifePoints, isDark, 0) { }
        public Wizard(string name, int lifePoints, int wandId) : this(name,lifePoints, false, wandId) { }
        public Wizard(string name, int lifePoints, bool isDark, int wandId)
        {
            Name = name;
            LifePoints = lifePoints;
            IsDark = isDark;
            WandId = wandId;
        }
        #endregion

        public void Attack(Wizard magician )
        {
            if (magician.Name != Name) {
                magician.LifePoints -= 10;
            }
        }
    }
}
