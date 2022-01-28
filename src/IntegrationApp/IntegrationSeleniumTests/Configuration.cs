using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationSeleniumTests
{
    static class Configuration
    {
        public static string Host
        {
            get => Environment.GetEnvironmentVariable("MF_HOST") ?? "http://localhost:3001";
        }

        public static string DrugstorePageUrl
        {
            get => Host + "/drugstore/1";
        }

        public static string DrugPurchasePageUrl
        {
            get => Host + "/purchase";
        }

        public static string DrugConsumptionReportPageUrl
        {
            get => Host + "/drugs-consumption";
        }

        public static string TendersPageUrl
        {
            get => Host + "/tender";
        }


    }
}
