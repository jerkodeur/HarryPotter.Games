using HarryPotter.Games.Core.Models.Force;
using JerkoLibs.Core.Common;
using JerkoLibs.Core.Common.Interfaces;
using JerkoLibs.Core.Console;

namespace HarryPotter.Games.Core.Models
{
    public abstract class AbstractCharacter
    {
        #region Class Params

        public const int DEFAULT_LIFEPOINTS = 100;
        public String Name { get; set; } = String.Empty;
        public IPosition CurrentPosition { get; set; } = new RandomPositionCalculator().Compute();
        public AbstractForce? Force { get; set; }
        public int Dammage = 10;
        private int lifePoints = DEFAULT_LIFEPOINTS;

        public int LifePoints
        {
            get => lifePoints;
            set
            {
                lifePoints = value;
                if(lifePoints <= 0) {
                    lifePoints = 0;
                    IsDead?.Invoke(this);
                }
            }
        }

        public event Action<AbstractCharacter>? IsDead;

        #endregion

        #region Constructors
        public AbstractCharacter() : this("Umber") { }
        public AbstractCharacter(string name)
        {
            Name = name;
            LifePoints = DEFAULT_LIFEPOINTS;
        }

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
            this.CurrentPosition = position;
            Move();
        }

        /// <summary>
        /// Allow the character moving on a new position
        /// </summary>
        public void Move(IPositionCalculator positionCalculator)
        {
            Move(positionCalculator.Compute());
        }

        /// <summary>
        /// Allow the caracter to attack with default dammages
        /// </summary>
        /// <param name="ennemy"></param>
        public void Attack(AbstractCharacter ennemy)
        {
            ennemy.takeDamages(ennemy.Dammage);
            DisplayDammage(ennemy, Dammage);
        }

        /// <summary>
        /// Allow the caracter to attack with specified dammages
        /// </summary>
        /// <param name="ennemy"></param>
        /// <param name="damage"></param>
        public void Attack(AbstractCharacter ennemy, int damage)
        {
            bool isDifferentCharacter = this != ennemy && Name != ennemy.Name;

            if (isDifferentCharacter)
            {
                DisplayDammage(ennemy, damage);
                ennemy.takeDamages(damage);
                if (ennemy.LifePoints > 0) { 
                    DisplayRemainingLifePoints(ennemy);
                }
            }
        }

        #region Private methods

        /// <summary>
        /// The character suffers damage
        /// </summary>
        /// <param name="damage"></param>
        private void takeDamages(int damage)
        {
            LifePoints -= damage;
        }

        private void DisplayDammage(AbstractCharacter ennemy, int damage)
        {
            ConsoleLine.WriteLine($"{Name} attaque {ennemy.Name} pour {damage} points", ConsoleColor.Yellow);
        }

        private void DisplayRemainingLifePoints(AbstractCharacter ennemy)
        {
            ConsoleLine.WriteLine($"Il reste {ennemy.LifePoints} points de vie à {ennemy.Name}", ConsoleColor.Yellow);
        }

        #endregion

        public override string ToString()
        {
            return String.Format("Name: {0}, LifePoints: {1}, Position: {2}", Name, LifePoints, CurrentPosition);
        }

        #endregion
    }
}
