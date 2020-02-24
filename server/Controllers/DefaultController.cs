using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public DefaultModel  DefaultGet()
        {
            return new DefaultModel
            {
                test = true,
                helloworld = "yes",
            };
        }

        public class DefaultModel
        {
            public bool test { get; set; }
            public string helloworld { get; set; }
        }
    }


}