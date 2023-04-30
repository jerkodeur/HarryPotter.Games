using System.Data;
using System.Data.SqlClient;
using HarryPotter.Games.Core.Settings;

namespace HarryPotter.Games.Core.Layers;
public class GameDbSettingsDataLayer: DbDataLayer<Game, GameSettings>
{
    public GameDbSettingsDataLayer () : base() { }

    public GameSettings? Read (int gameId)
    {
        GameSettings? settings = null;

        using var connexion = _connection;
        using var command = connexion.CreateCommand();
        command.CommandText = $"SELECT * FROM Settings WHERE Id = {gameId}";

        try
        {
            _connection.Open ();

            using var reader = command.ExecuteReader();

            while(reader.Read())
            {
                int gridRows = reader.GetInt16("GridRows");
                int gridCols = reader.GetInt16("GridCols");
                settings = new GameSettings(gridRows, gridCols);
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

        return settings;
    }

    public override void Write (Game game)
    {
        using(SqlConnection connection = _connection)
        {
            try
            {
                connection.Open();

                using(var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Settings (GridRows, GridCols, GameId) VALUES(@gridRows,@gridCols, @gameId)";

                    command.Parameters.AddWithValue("@gridRows", game.grid.Rows);
                    command.Parameters.AddWithValue("@gridCols", game.grid.Cols);
                    command.Parameters.AddWithValue("@gameId", game.Id);

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
}
