using System;

namespace LA.Domain
{
    public class Drawing
    {
        public Drawing(DateTime dateTime, int[] numbers, int superNumber)
        {
            DateTime = dateTime;
            Numbers = numbers;
            SuperNumber = superNumber;
        }

        public DateTime DateTime { get; }

        public int[] Numbers { get; }

        public int SuperNumber { get; }
    }
}
