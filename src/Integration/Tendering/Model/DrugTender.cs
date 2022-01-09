using System;
using System.ComponentModel.DataAnnotations;

namespace Integration.Tendering.Model
{
    public class DrugTender
    {
        [Key]
        public int Id { get; set; }
        public DateTime TenderEnd { get; set; }
        public String TenderInfo { get; set; }
        public bool isFinished { get; set; }

        public DrugTender(int id, DateTime tenderEnd, string tenderInfo, bool isFinished)
        {
            Id = id;
            TenderEnd = tenderEnd;
            TenderInfo = tenderInfo;
            this.isFinished = isFinished;
        }

        public DrugTender(DateTime tenderEnd, string tenderInfo, bool isFinished)
        {
            TenderEnd = tenderEnd;
            TenderInfo = tenderInfo;
            this.isFinished = isFinished;
        }
        public DrugTender()
        {
        }
    }
}
