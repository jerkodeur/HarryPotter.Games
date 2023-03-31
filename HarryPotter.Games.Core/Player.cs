using JerkoLibs.Core.Date;

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
            Age = DateCalculators.getPlayerAge(birthday);
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Age: {1}, DefaultWeapon: {2}, Position: {3}", Name, Age, DefaultWeapon, CurrentPosition.ToString());
        }
    }
}
