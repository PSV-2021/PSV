using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Tendering.DTO
{
    public class TenderChartInfoDTO
    {
        public int DrugstoreId { get; set; }
        public string DrugstoreName { get; set; }
        public int Wins { get; set; }
        public double Profit { get; set; }
        public int Participations {get; set; }

        public TenderChartInfoDTO(int drugstoreId, string drugstoreName, int wins, double profit, int participations)
        {
            DrugstoreId = drugstoreId;
            DrugstoreName = drugstoreName;
            Wins = wins;
            Profit = profit;
            Participations = participations;
        }

        public TenderChartInfoDTO()
        {
        }
    }
}
