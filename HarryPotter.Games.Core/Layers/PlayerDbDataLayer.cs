using System.Data.SqlClient;
using System.Data;

namespace HarryPotter.Games.Core.Layers;
public class PlayerDbDataLayer: DbDataLayer<Player, Player>
{
    public PlayerDbDataLayer(): base() { }

    #region Public methods
    public Player? Read (int playerId)
    {
        Player player = null;
        using var connexion = _connection;
        using var command = connexion.CreateCommand();
        command.CommandText = $"SELECT * FROM Character WHERE Id = {playerId}";

        try
        {
            _connection.Open();
            using var reader = command.ExecuteReader();

            while(reader.Read())
            {
                player = new(reader.GetString("Name"), reader.GetString("Email"), DateOnly.FromDateTime(reader.GetDateTime("Birdhday")))
                {
                    Dammage = reader.GetInt16("Dammage"),
                    LifePoints = reader.GetInt16("LifePoints"),
                    Force = new Force().Forces[reader.GetInt16("ForceId")],
                    CurrentPosition = new Position(reader.GetInt16("PositionX"), reader.GetInt16("PositionY"))
                };
            }
            reader.Close();
        }
        finally
        {
            if(connexion.State != ConnectionState.Closed)
            {
                Disconnect();
            }
        }

        return player;
    }

    public override void Write (Game game, Player player)
    {
        using(SqlConnection connection = _connection)
        {
            try
            {
                connection.Open();

                using(var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [dbo].[Character] ([Name],[Email],[Birthday],[LifePoints],[Dammage],[GameId],[ForceId],[PositionX],[PositionY]) " +
                        "VALUES (@name,@email, @birthday, @lifepoints, @dammage, @gameId, @forceId, @XPosition, @YPosition)";

                    command.Parameters.AddWithValue("@name", player.Name);
                    command.Parameters.AddWithValue("@email", player.Email);
                    command.Parameters.AddWithValue("@birthday", player.Birthday.ToString());
                    command.Parameters.AddWithValue("@lifepoints", player.LifePoints);
                    command.Parameters.AddWithValue("@dammage", player.Dammage);
                    command.Parameters.AddWithValue("@gameId", game.Id);
                    command.Parameters.AddWithValue("@forceId", player.Force?.Id);
                    command.Parameters.AddWithValue("@XPosition", player.CurrentPosition.X);
                    command.Parameters.AddWithValue("@YPosition", player.CurrentPosition.Y);

                    command.ExecuteNonQuery();
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
