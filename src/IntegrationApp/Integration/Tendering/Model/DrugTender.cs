using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Integration.Tendering.Model
{
    public class DrugTender
    {
        [Key]
        public string Id { get; set; }
        public DateTime TenderEnd { get; set; }
        public String TenderInfo { get; set; }
        public bool isFinished { get; set; }

        public DrugTender(string id, DateTime tenderEnd, string tenderInfo, bool isFinished)
        {
            Id = id;
            TenderEnd = IsTenderEndValid(tenderEnd) ? tenderEnd : DateTime.Now.AddDays(10);
            TenderInfo = IsDrugFormatValid(tenderInfo) ? tenderInfo : "";
            this.isFinished = isFinished;
        }

        public DrugTender(DateTime tenderEnd, string tenderInfo, bool isFinished)
        {
            TenderEnd = IsTenderEndValid(tenderEnd) ? tenderEnd : DateTime.Now.AddDays(10);
            TenderInfo = IsDrugFormatValid(tenderInfo) ? tenderInfo : "";
            this.isFinished = isFinished;
        }
        public DrugTender()
        {
        }

        private bool IsDrugFormatValid(string info)
        {
            Regex MyPattern = new Regex(@"(([a-zA-Z0-9\s]*) - ([0-9]{1,},{0,1})){1,}");
            if (MyPattern.IsMatch(info))
                return true;
            return false;
        }

        private bool IsTenderEndValid(DateTime tenderEnd)
        {
            if (tenderEnd < DateTime.Now)
                return true;
            return false;
        }
    }
}
