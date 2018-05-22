using System.Collections.Generic;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;

namespace LA.WebApi.Controllers
{
    public class IndexGetController : ControllerBase
    {
        public IActionResult Get()
        {
            var links = new[]
            {
                new Link(Link.RelForSelf, "/"),
                new Link("values", "/values{?from,to}")
            };

            return this.HAL(new HALResponse(null).AddLinks(links));
        }
    }
}
