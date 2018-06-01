using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LA.Domain;

namespace LA.Services
{ 
    public class DrawingProvider : IDrawingProvider
    {
        private Stream stream;
        private Drawing[] drawings;

        public DrawingProvider(Stream stream)
        {
            this.stream = stream;
        }

        private static IEnumerable<string> GetDataSets(Stream stream)
        {
            stream.Position = 0;
            var streamReader = new StreamReader(stream);
            var content = streamReader.ReadToEnd();

            return content.Split('\n').TakeWhile(x => !string.IsNullOrEmpty(x));
        }

        public Drawing[] GetNumbers(DateRange dateRange)
        {
            if (drawings == null)
            {
                var dataSets = GetDataSets(this.stream);
                drawings = dataSets.Select(x => ConvertToDrawing(x)).ToArray();
            }
            
            return this.drawings.Where(x => x.DateTime >= dateRange.From && x.DateTime <= dateRange.To).ToArray();
        }

        private static Drawing ConvertToDrawing(string dataSet)
        {
            var parts = dataSet.Split(';');
            var strings = parts.Skip(1).Take(6).ToArray();
            var dateValue = ConvertToDate(parts[0]);
            var numbers = ConvertToNumbers(strings).OrderBy(x => x).ToArray();

            return new Drawing(dateValue, numbers, Convert.ToInt32(parts.Last()));
        }

        private static int[] ConvertToNumbers(string[] numberStrings)
        {
            return numberStrings.Select(x => Convert.ToInt32(x)).ToArray();
        }

        private static DateTime ConvertToDate(string date)
        {
            var dateParts = date.Split('.');
            var day = Convert.ToInt32(dateParts[0]);
            var month = Convert.ToInt32(dateParts[1]);
            var year = Convert.ToInt32(dateParts[2]);
            var dateValue = new DateTime(year, month, day);
            return dateValue;
        }
    }
}