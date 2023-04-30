using HarryPotter.Games.Core.Models;
using HarryPotter.Games.Core.Models.Force;
using JerkoLibs.Core.Date;

namespace HarryPotter.Games.Core
{
    /// <summary>
    /// Represents the player in the game
    /// </summary>
    public class Player : Character
    {
        public string DefaultWeapon { get; set; } = string.Empty;
        public override ForceItem Force { get; set; } = new NeutreForce();
        public DateOnly Birthday { get; set; }
        public string Email { get; set; }
        private int _age { get; init; }

        public Player(): base() { }

        public Player(string name, string email, DateOnly birthday) : base(name)
        {
            Birthday = birthday;
            Email = email;
            _age = DateCalculators.getPlayerAge(birthday);
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Age: {1}, DefaultWeapon: {2}, Position: {3}", Name, _age, DefaultWeapon, CurrentPosition?.ToString());
        }
    }
}
