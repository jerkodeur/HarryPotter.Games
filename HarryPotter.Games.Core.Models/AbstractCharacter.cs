using JerkoLibs.Core.Common;
using JerkoLibs.Core.Common.Interfaces;
using JerkoLibs.Core.Console;

namespace HarryPotter.Games.Core.Models
{
    public abstract class Character
    {
        #region Class Params
        public const int DEFAULT_LIFEPOINTS = 100;
        public String Name { get; set; } = String.Empty;
        public IPosition CurrentPosition { get; set; } = new RandomPositionCalculator().Compute();
        public int LifePoints { get; set; } = DEFAULT_LIFEPOINTS;
        public IForce? Force { get; set; }
        #endregion

        #region Constructors
        public Character() : this("Umber") { }
        public Character(string name) => Name = name; 
        #endregion

        #region Public Methods

        /// <summary>
        /// Allow the character to move
        /// </summary>
        public virtual void Move()
        {
            ConsoleLine.WriteLine($"{Name} se déplace en {CurrentPosition}", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Allow the character moving on a new position
        /// </summary>
        public void Move(IPosition position)
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

        #region Private methods
        /// <summary>
        /// The character suffers damage
        /// </summary>
        /// <param name="damage"></param>
        private void takeDamages(int damage)
        {
            this.LifePoints -= damage;
            ConsoleLine.WriteLine($"{Name} possède désormais {this.LifePoints} points de vie !", ConsoleColor.Red);
        } 
        #endregion

        public override string ToString()
        {
            return String.Format("Name: {0}, LifePoints: {1}, Position: {2}", Name, LifePoints, CurrentPosition);
        }

        #endregion
    }
}
