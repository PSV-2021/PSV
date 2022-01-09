using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Shared_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Integration.Model
{
    [Owned]
    public class DateRange: ValueObject
    { 
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public DateRange(DateTime from, DateTime to)
        {
            if(to.Equals(DateTime.MinValue))
                to = DateTime.MaxValue;

            if (from.CompareTo(to) > 0) throw new ArgumentException("DateTime from must be before DateTIme to");

            this.From = from;
            this.To = to;
        }

        public DateRange ConvertDateFromAngular()
        {
            return new DateRange(From.AddHours(1), To.AddHours(1));
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
