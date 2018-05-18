using System.Collections.Generic;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;

namespace LA.WebApi.Controllers
{
    public class IndexController : ControllerBase
    {
        public IActionResult Get()
        {
            var links = new LinkedList<Link>();
            links.AddLast(new Link(Link.RelForSelf, "/"));

            return this.HAL(new HALResponse(null).AddLinks(links));
        }
    }
}
