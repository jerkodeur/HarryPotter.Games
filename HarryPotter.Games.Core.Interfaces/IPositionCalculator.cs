namespace HarryPotter.Games.Core.Interfaces
{
    public interface IPositionCalculator
    {
        /// <summary>
        /// Calculate a new position for a given character
        /// </summary>
        /// <returns></returns>
        PlayerPosition Compute();
    }
}
