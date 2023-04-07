using HarryPotter.Games.Core.Models;
using System.Collections;

namespace HarryPotter.Games.Core
{
    public class GameGrid : AbstractGrid, IList<GameCell>
    {
        #region Properties
        private List<GameCell> Cells { get; init; } = new();
        public int Count => Cells.Count;
        public bool IsReadOnly => false;
        public GameCell this[int index] { get => Cells[index]; set => Cells[index] = value; }

        #endregion
        #region Constructors
        public GameGrid(int rows, int cols) : base(rows, cols)
        {
            Cells = InitializeCells();
        } 

        #endregion
        #region Public Methods
        public void AddCharacterToPosition(Position position, AbstractCharacter character)
        {
            if (IsCharacterOnCell(character, position) == false)
            {
                GameCell? cell = GetCell(position)?.SingleOrDefault();
                cell?.Add(character);

                character.Move(position);
            }
            else
            {
                ConsoleErrorLine.WriteLine("Le personnage se trouve déjà sur à cet emplacement");
            }
        }

        public bool? IsCharacterOnCell(AbstractCharacter character, Position position)
        {
            return GetCell(position).SingleOrDefault()?.IsCharacterOnCell(character);
        }

        public List<GameCell> GetEmptyCells()
        {   
            return Cells.Where(cell => cell.IsCellEmpty()).ToList();
        }

        public List<GameCell> GetBusyCells()
        {
            return Cells.Where(cell => cell.IsCellBusy()).ToList();
        }
        public List<AbstractCharacter>? GetCharactersOnCell(Position position)
        {
            return GetCell(position).SingleOrDefault()?.Characters;
        }

        public Position? GetCharacterPositionOnGrid(AbstractCharacter character)
        {
            IEnumerable<Position> query = from cell in GetBusyCells()
                                          where cell.IsCharacterOnCell(character)
                                          select new Position(cell.Position.X, cell.Position.Y);
            return query.SingleOrDefault();
        }

        public bool? IsCellBusy(Position position)
        {
            return GetCell(position).SingleOrDefault()?.IsCellBusy();
        }

        public bool? IsFightPossibleOnCell(AbstractCharacter character, Position position)
        {
            return GetCell(position)
                .Where(cell => cell.IsCharacterOnCell(character) && cell.Count > 1)
                .SingleOrDefault()?.Count > 1;
        } 

        #endregion
        #region Utilities Methods
        public int IndexOf(GameCell item)
        {
            return Cells.IndexOf(item);
        }

        public void Insert(int index, GameCell item)
        {
            Cells.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            Cells.RemoveAt(index);
        }

        public void Add(GameCell item)
        {
            Cells.Add(item);
        }

        public void Clear()
        {
            Cells.Clear();
        }

        public bool Contains(GameCell item)
        {
            return Cells.Contains(item);
        }

        public void CopyTo(GameCell[] array, int arrayIndex)
        {
            Cells.CopyTo(array, arrayIndex);
        }

        public bool Remove(GameCell item)
        {
            return Cells.Remove(item);
        }

        public IEnumerator<GameCell> GetEnumerator()
        {
            return Cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Cells.GetEnumerator();
        }

        #endregion
        #region Private Methods
        private List<GameCell> InitializeCells()
        {
            var cells = new List<GameCell>();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    cells.Add(new GameCell(i, j));
                }
            }

            return cells;
        }

        private IEnumerable<GameCell> GetCell(Position position)
        {
            return Cells.Where(cell => cell.Position == position);
        }

        #endregion
        #region ToString Method
        public override string ToString()
        {
            return String.Format($"La grille mesure {Rows} de longueur par {Cols} de largeur");
        }

        #endregion
    }
}
