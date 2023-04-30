using System.Data;
using System.Data.SqlClient;
using HarryPotter.Games.Core.Settings;

namespace HarryPotter.Games.Core.Layers;
public class GameDbDataLayer: DbDataLayer<Game, Game>
{
    public GameDbDataLayer () : base() { }

    public Game? Read (Player player)
    {
        Game? game = null;
        using var connexion = _connection;
        using var command = connexion.CreateCommand();

        try
        {
            _connection.Open();

            // Get Player
            command.CommandText = $"SELECT * FROM Character where Id = {player.Id}";
            using var reader1 = command.ExecuteReader();

            while(reader1.Read())
            {
                int gameId = reader1.GetInt16("GameId");
                GameSettings settings = getSettings(gameId);
                game = new Game(gameId, settings.Grid.Rows, settings.Grid.Cols)
                {
                    Player = getPlayer(player)
                };
                List<Ennemy> ennemies = getEnnemies(game);
                game.Ennemies.AddRange(ennemies);
            }

            reader1.Close();
        }
        finally
        {
            if(connexion.State != ConnectionState.Closed)
            {
                Disconnect();
            }
        }

        return game;
    }

    public void Write ()
    {
        using(SqlConnection connection = _connection)
        {
            try
            {
                connection.Open();

                using(var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO Game OUTPUT INSERTED.id DEFAULT VALUES";
                    InsertedId = (int) command.ExecuteScalar();
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

    private Player? getPlayer(Player player)
    {
        return new PlayerDbDataLayer().Read(player.Id);
    }
    
    private List<Ennemy>? getEnnemies(Game game)
    {
        return new EnnemyDbDataLayer().ReadList(game);
    }

    private GameSettings? getSettings (int gameId)
    {
        return new GameDbSettingsDataLayer().Read(gameId);
    }
}
