using System.Data.SqlClient;
using JerkoLibs.Core.DataLayers.Interfaces;
using Microsoft.Extensions.Configuration;

namespace HarryPotter.Games.Core.Layers;
public abstract class DbDataLayer<TItemIn, TItemOut>: ISqlConnection, IDataLayer<TItemIn, TItemOut> 
    where TItemIn : class 
    where TItemOut : class
{
    protected string? _connectionString { get; private set; } = String.Empty;
    protected SqlConnection _connection = new();
    public int InsertedId { get; protected set; }

    protected DbDataLayer ()
    {
        Connect();
    }

    public void Connect ()
    {
        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        string server = configuration.GetConnectionString("HarryPotter.Games.Server");
        string database = configuration.GetConnectionString("HarryPotter.Games.Database");
        _connectionString = $"Server={server};Database={database};Trusted_Connection=True;";
        _connection = new SqlConnection(_connectionString);
    }

    public void Disconnect ()
    {
        _connection.Dispose();
    }

    public virtual void ReadOnly (TItemIn item) => throw new NotImplementedException();
    public virtual TItemOut? Read (TItemIn item) => throw new NotImplementedException();
    public virtual List<TItemOut>? ReadList () => throw new NotImplementedException();
    public virtual List<TItemOut>? ReadList (Game game) => throw new NotImplementedException();
    public virtual void Write (TItemIn item) => throw new NotImplementedException();
    public virtual void Write (Game game, TItemIn item) => throw new NotImplementedException();
}