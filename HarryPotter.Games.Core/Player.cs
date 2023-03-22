namespace HarryPotter.Games.Core
{
    /// <summary>
    /// Represents the player in the game
    /// </summary>
    public class Player
    {
        public const int DEFAULT_LIFEPOINTS = 100;

        public Player(DateOnly birthday)
        {
            this.birthday = birthday;
            this.setPlayerAge();
        }

        public string Name { get; set; }
        public string DefaultWeapon { get; set; }
        public int Age { get; private set; }
        private DateOnly birthday { get; set; }
        private int LifePoints { get; set; } = DEFAULT_LIFEPOINTS;

        private void setPlayerAge()
        {
            int age = DateTime.Now.Year - this.birthday.Year;

            if(DateTime.Now.DayOfYear < this.birthday.DayOfYear)
            {
                age -= 1;
            }

            this.Age = age;
        }

        public void Move()
        {
            Console.WriteLineWithColors("Je me déplace", ConsoleColor.Yellow);
        }
        public void Attack(Ennemy ennemy, int damage)
        {
            Console.WriteLineWithColors($"{this.Name} attaque {ennemy.Name} et le blesse de {damage} points", ConsoleColor.Yellow);
            ennemy.isAttacked(20);
        }
    }
}
