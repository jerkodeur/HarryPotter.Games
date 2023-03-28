using HarryPotter.Games.Core.Interfaces;
using PlayerPosition = HarryPotter.Games.Core.Models.PlayerPosition;

namespace HarryPotter.Games.Core
{
    public abstract class Character
    {
        #region Class Params

        public const int DEFAULT_LIFEPOINTS = 100;

        public String Name { get; set; } = String.Empty;
        public PlayerPosition CurrentPosition { get; set; } = new PlayerPosition();
        public int LifePoints { get; set; } = DEFAULT_LIFEPOINTS;
        public Force ? Force { get; set; }

        #endregion

        // Appelle un autre constructeur
        public Character() : this("Umber") { }

        public Character(string name) => Name = name;

        #region Class Methods

        /// <summary>
        /// Allow the character to move
        /// </summary>
        public virtual void Move()
        {
            ConsoleLine.WriteLine($"{Name} se déplace", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Allow the character moving on a new position
        /// </summary>
        public void Move(PlayerPosition position)
        {
            Move();
            this.CurrentPosition = position;
        }

        public void Move(IPositionCalculator positionCalculator)
        {
            Move(positionCalculator.Compute());
        }

        /// <summary>
        /// Allow the caracter to attack
        /// </summary>
        /// <param name="ennemy"></param>
        /// <param name="damage"></param>
        public void Attack(Character ennemy, int damage)
        {
            ConsoleLine.WriteLine($"{this.Name} attaque {ennemy.Name} pour {damage} points", ConsoleColor.Yellow);
            ennemy.takeDamages(damage);
        }

        /// <summary>
        /// The character suffers damage
        /// </summary>
        /// <param name="damage"></param>
        private void takeDamages(int damage)
        {
            this.LifePoints -= damage;
            ConsoleLine.WriteLine($"{Name} possède désormais {this.LifePoints} points de vie !", ConsoleColor.Red);
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, LifePoints: {1}, Position: {2}", Name, LifePoints, CurrentPosition);
        }

        #endregion
    }
}
