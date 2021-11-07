using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.Filters
{
    [AttributeUsage(validOn:AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = configuration.GetValue<string>(key:"ApiKey");

            if (!apiKey.Equals(potentialApiKey)) 
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }

        //public string getApi()
        //{
        //    // Connect to a PostgreSQL database
        //    NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres; " +
        //       "Password=pwd;Database=postgres;");
        //    conn.Open();

        //    // Define a query returning a single row result set
        //    NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM cities", conn);

        //    // Execute the query and obtain the value of the first column of the first row
        //    Int64 count = (Int64)command.ExecuteScalar();

        //    Console.Write("{0}\n", count);
        //    conn.Close();
        //}
    }
}
