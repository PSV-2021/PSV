using System;

namespace DrugstoreApiTests
{
    public class Constants //Ova klasa mozda moze da ide u .gitignore...
    {

        public static string ConnectionString()
        {
            var server = Environment.GetEnvironmentVariable("DBServer") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DBPort") ?? "5432";
            var user = Environment.GetEnvironmentVariable("DBUser") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("DBPassword") ?? "firma4";
            var database = Environment.GetEnvironmentVariable("DBTest") ?? "drugstoreTest";
            Console.WriteLine(server);
            return $"server={server}; port={port}; database={database}; User Id={user}; password={password}";
        }

    }
}
