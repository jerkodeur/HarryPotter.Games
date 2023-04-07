using HarryPotter.Games.Core.Models;
using JerkoLibs.Core.Common.Interfaces;
using System.Collections;

namespace HarryPotter.Games.Core
{
    public class GameCell : AbstractCell, ICell, IList<AbstractCharacter>
    {
        #region Properties

        public List<AbstractCharacter> Characters { get; private set; } = new List<AbstractCharacter>();

        public int Count => Characters.Count();
        public bool IsReadOnly => false;
        public AbstractCharacter this[int index] { get => Characters[index]; set => Characters[index] = value; } 

        #endregion
        #region Constructors
        public GameCell(Position position) : base(position) { }
        public GameCell(int x, int Y) : base(x, Y) { }

        #endregion
        #region Public Methods

        public bool IsCellBusy() => Characters.Any();
        public bool IsCellEmpty() => !Characters.Any();
        public bool IsCharacterOnCell(AbstractCharacter character) => Characters.Contains(character);

        #endregion
        #region Operators Override

        public static bool operator ==(GameCell cell1, GameCell cell2) => cell1.Position == cell2.Position;
        public static bool operator !=(GameCell cell1, GameCell cell2) => cell1.Position != cell2.Position; 

        #endregion
        #region IList Implementation Methods

        public int IndexOf(AbstractCharacter item)
        {
            return Characters.IndexOf(item);
        }

        public void Insert(int index, AbstractCharacter item)
        {
            Characters.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            Characters.RemoveAt(index);
        }

        public void Add(AbstractCharacter item)
        {
            Characters.Add(item);
        }

        public void Clear()
        {
            Characters.Clear();
        }

        public bool Contains(AbstractCharacter item)
        {
            return Characters.Contains(item);
        }

        public void CopyTo(AbstractCharacter[] array, int arrayIndex)
        {
            Characters.CopyTo(array, arrayIndex);
        }

        public bool Remove(AbstractCharacter item)
        {
           return Characters.Remove(item);
        }

        public IEnumerator<AbstractCharacter> GetEnumerator()
        {
            return Characters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return Characters.GetEnumerator ();
        } 
        #endregion
    }
}
