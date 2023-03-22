namespace HarryPotter.Games.Core.Exceptions
{
    public class AgeNotValidException : Exception
    {
        private string message = "L'age renseigné n'est pas valide !";

        string GetMessage()
        {
            return message;
        }
    }
}
