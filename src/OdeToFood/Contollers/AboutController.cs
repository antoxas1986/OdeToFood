using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Contollers
{
    [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public String Phone() {
            return "555-555-5555";
        }
        [Route("[action]")]
        public String Country() {
            return "USA";
        }
    }
}
