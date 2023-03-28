namespace HarryPotter.Games.Core
{
    /// <summary>
    /// Represents the player in the game
    /// </summary>
    public class Player : Character
    {
        public string DefaultWeapon { get; set; } = string.Empty;
        public int Age { get; init; }
        private DateOnly birthday { get; set; }

        public Player() : base() { }
        public Player(string name, DateOnly birthday) : base(name)
        {
            Age = setPlayerAge(birthday);
        }

        public Player(DateOnly birthday) : base()
        {
            Age = setPlayerAge(birthday);
        }

        private int setPlayerAge(DateOnly birthday)
        {
            this.birthday = birthday;

            int age = DateTime.Now.Year - birthday.Year;

            if(DateTime.Now.DayOfYear < birthday.DayOfYear)
            {
                age -= 1;
            }

            return age;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Age: {1}, DefaultWeapon: {2}, Position: {3}", Name, Age, DefaultWeapon, CurrentPosition.ToString());
        }
    }
}
