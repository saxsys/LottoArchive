using System;
using System.Diagnostics;

namespace LA.Domain
{
    [DebuggerDisplay("{From} - {To}")]
    public struct DateRange
    {
        public DateRange(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }

        public DateTime From { get; }

        public DateTime To { get; }
    }

    public static class DateTimeExtensions
    {
        public static DateRange To(this DateTime from, DateTime to) => new DateRange(from, to);
    }
}
