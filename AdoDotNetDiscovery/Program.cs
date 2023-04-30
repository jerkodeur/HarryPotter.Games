using System.Data;
using System.Data.SqlClient;

using (SqlConnection connection = new())
{
    connection.ConnectionString = "Server=JERKO-LEGION\\SQLEXPRESS;Database=HarryPotter.Udemy.Database;Trusted_Connection=True;";
	try
    {
        connection.Open();

        using(var command = connection.CreateCommand())
        {
            #region Read data in database
            // Creation de la commande
            command.CommandText = "Select * from Ennemy"; // Make a command in Sql language

            #region Use Reader to fetch data
            // Début du stream de lecture des données de la table
            using(var reader = command.ExecuteReader())
            {
                // Pour chaque tuple correspondant à la requête
                while(reader.Read())
                {
                    Console.WriteLine(reader["Id"]);
                    Console.WriteLine(reader["Name"]);
                    Console.WriteLine(reader["LifePoints"]);
                }
            }
            #endregion

            #region Use DataTable to fetch and handle data
            // Début du stream de lecture des données de la table
            using(var reader = command.ExecuteReader())
            {
                // Une dataTable simule une base de données (garde en mémoire tampon)
                DataTable dataTable = new();

                // Execute la requête et contient toutes les lignes correspondantes
                dataTable.Load(reader);

                foreach(DataRow row in dataTable.Rows)
                {
                    Console.Write(row["Id"] + " ");
                    Console.Write(row["Name"] + " ");
                    Console.Write(row["LifePoints"]);
                    Console.WriteLine();
                }
            }
            #endregion
            #endregion
            #region Write in database
            // Creation de la commande
            command.CommandText = "INSERT INTO Ennemy (Name, LifePoints) VALUES('Jéjé la terreur', 300)";

            // Exécute une commande qui ne récupère pas de données en base
            command.ExecuteNonQuery();
            #endregion
        }
    }
    catch(Exception ex)
	{
        Console.WriteLine("An error is occured...", ex.Message);
    }
	finally 
	{ 
        if(connection.State != System.Data.ConnectionState.Closed)
        {
		    connection.Close(); 
        }
	}
};
