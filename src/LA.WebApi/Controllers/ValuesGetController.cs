using System;
using System.Linq;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using LA.Domain;
using LA.Services;
using Microsoft.AspNetCore.Mvc;

namespace LA.WebApi.Controllers
{
    [Route("[controller]")]
    public class ValuesGetController : ControllerBase
    {
        private readonly IDrawingProvider drawingProvider;

        public ValuesGetController(IDrawingProvider drawingProvider)
        {
            this.drawingProvider = drawingProvider;
        }

        [HttpGet("/values")]
        public IActionResult Get(DateTime from, DateTime to)
        {
            var dateRange = new DateRange(@from, to);
            var numbers = this.drawingProvider.GetNumbers(dateRange);
            if (!numbers.Any())
            {
                return this.NotFound();
            }

            var model = new ValueRepresentation
            {
                Values = numbers
            };

            var links = new[]
            {
                new Link(Link.RelForSelf, $"/values?from={from}&to={to}")
            };

            return this.HAL(new HALResponse(model).AddLinks(links));
        }
    }

    public class ValueRepresentation
    {
        public Drawing[] Values { get; set; }
    }
}
