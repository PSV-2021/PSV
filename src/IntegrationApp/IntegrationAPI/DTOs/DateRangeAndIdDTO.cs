using System;

namespace Integration_API.DTOs

{
    
    public class DateRangeAndIdDTO
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }
        public int Id { get; set; }

        public DateRangeAndIdDTO(DateTime from, DateTime to, int id)
        {
            if (to.Equals(DateTime.MinValue))
                to = DateTime.MaxValue;

            if (from.CompareTo(to) > 0) throw new ArgumentException("DateTime from must be before DateTIme to");

            this.From = from;
            this.To = to;
            this.Id = id;
        }

        public DateRangeAndIdDTO ConvertDateFromAngular()
        {
            return new DateRangeAndIdDTO(From.AddHours(1), To.AddHours(1), Id);
        }

        public DateRangeAndIdDTO()
        { }

        
    }
}
