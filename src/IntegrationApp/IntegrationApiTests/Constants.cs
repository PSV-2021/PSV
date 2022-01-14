using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationApiTests
{
    public static class Constants
    {
        public static string ConnectionString()
        {
            var server = Environment.GetEnvironmentVariable("DBServer") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DBPort") ?? "5432";
            var user = Environment.GetEnvironmentVariable("DBUser") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("DBPassword") ?? "firma4";
            var database = Environment.GetEnvironmentVariable("DBTest") ?? "hospital";
            return $"server={server}; port={port}; database={database}; User Id={user}; password={password}";
        }
    }
}
