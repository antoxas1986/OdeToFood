using Microsoft.AspNet.Mvc;
using System;

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
