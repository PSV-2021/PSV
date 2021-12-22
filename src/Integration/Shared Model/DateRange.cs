using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Shared_Model;
using Microsoft.VisualBasic;

namespace Integration.Model
{
    public class DateRange: ValueObject
    { 
        public DateTime From { get; }

        public DateTime To { get;  }

        public DateRange(DateTime from, DateTime to)
        {
            if (from.Equals(DateTime.MinValue) || to.Equals(DateTime.MinValue))
                throw new ArgumentException("Both dates must be entered!");

            if(from.CompareTo(to) > 0)
                throw new ArgumentException("Both dates must be entered!");

            this.From = from;
            this.To = to;
        }

        public DateRange ConvertDateFromAngular()
        {
            return new DateRange(To.AddHours(1), From.AddHours(1));
        }

        public DateRange()
        { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return From;
            yield return To;
        }
    }
}
