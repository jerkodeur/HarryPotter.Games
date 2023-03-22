namespace HarryPotter.Games.Core
{
    public class Ennemy
    {
        public const int DEFAULT_LIFEPOINTS = 100;
        
        public Ennemy(string name)
        {
            Name = name;
        }

        public String Name { get; set; }
        private int LifePoints { get; set; } = DEFAULT_LIFEPOINTS;

        public void Move()
        {
            Console.WriteLineWithColors($"{Name} se déplace", ConsoleColor.Yellow);
        }
        public void Attack(Ennemy ennemy, int damage)
        {
            Console.WriteLineWithColors($"{this.Name} attaque {ennemy.Name} pour {damage} points", ConsoleColor.Yellow);
            ennemy.isAttacked(20);
        }

        public void isAttacked(int damage)
        {
            this.LifePoints -= damage;
            Console.WriteLineWithColors($"{Name} possède désormais {LifePoints} points de vie !", ConsoleColor.Red);
        }
    }
}
