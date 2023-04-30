using System.Data;
using System.Data.SqlClient;
namespace HarryPotter.Games.Core.Layers;
public class EnnemyDbDataLayer : DbDataLayer<Ennemy, Ennemy>
{
    public EnnemyDbDataLayer () : base() { }

    #region Public methods
    public override List<Ennemy> ReadList (Game game)
    {
        List<Ennemy> ennemies = new();
        using var connexion = _connection;
        using var command = connexion.CreateCommand ();
        command.CommandText = $"SELECT * FROM Character WHERE Birthday = null AND GameId = {game.Id}";

        try
        {
            _connection.Open ();
            using var reader = command.ExecuteReader ();

            while (reader.Read ())
            {
                ennemies.Add(new(reader.GetString("Name"))
                {
                    Dammage = reader.GetInt16("Dammage"),
                    LifePoints = reader.GetInt16("LifePoints"),
                    Force = new Force().Forces[reader.GetInt16("ForceId")],
                    CurrentPosition = new Position(reader.GetInt16("PositionX"), reader.GetInt16("PositionY"))
                });
            }
            reader.Close ();
        }
        finally
        {
            if(connexion.State != ConnectionState.Closed)
            {
                Disconnect();
            }
        }

        return ennemies;
    }

    public override void Write (Game game, Ennemy ennemy)
    {
        using(SqlConnection connection = _connection)
        {
            try
            {
                connection.Open();

                using(var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [dbo].[Character] ([Name],[LifePoints],[Dammage],[GameId],[ForceId],[PositionX],[PositionY]) " +
                        "VALUES (@name, @lifepoints, @dammage, @gameId, @forceId, @XPosition, @YPosition)";

                    command.Parameters.AddWithValue("@name", ennemy.Name);
                    command.Parameters.AddWithValue("@lifepoints", ennemy.LifePoints);
                    command.Parameters.AddWithValue("@dammage", ennemy.Dammage);
                    command.Parameters.AddWithValue("@gameId", game.Id);
                    command.Parameters.AddWithValue("@forceId", ennemy.Force?.Id);
                    command.Parameters.AddWithValue("@XPosition", ennemy.CurrentPosition.X);
                    command.Parameters.AddWithValue("@YPosition", ennemy.CurrentPosition.Y);

                    command.ExecuteNonQuery ();
                }
            }
            finally
            {
                if(connection.State != ConnectionState.Closed)
                {
                    Disconnect();
                }
            }
        }
    }
   
    #endregion
}
