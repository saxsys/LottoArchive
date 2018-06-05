using System;
using System.Threading.Tasks;
using LA.Domain;

namespace LA.ConsoleClient
{
    class UserInteraction
    {
        private readonly IRepository repository;

        public UserInteraction(IRepository repository)
        {
            this.repository = repository;

        }

        public async Task Run()
        {
            var from = new DateTime(2016, 1, 1);
            var to   = new DateTime(2018, 1, 1);
            var range = new DateRange(from, to);
            var values = await this.repository.GetDrawings(range);

            foreach (var value in values)
            {
                Console.WriteLine(value.DateTime.ToShortDateString());
                foreach (var number in value.Numbers)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine(value.SuperNumber);
            }

            Console.ReadKey();
        }
    }
}
