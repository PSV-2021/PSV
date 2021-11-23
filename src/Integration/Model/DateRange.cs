using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Model
{
    public class DateRange
    { 
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public DateRange(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }

        public DateRange()
        {

        }

    }
}
