using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private static readonly string[] Coffees = new[]
        {
            "Ur coffee is: Flat White", "Ur coffee is: Long Black", 
            "Ur coffee is: Latte", "Ur coffee is: Americano", "Ur coffee is: Cappuccino"
        };

    
        [HttpGet]
        public ActionResult Get()
        {
            var rng = new Random();
            
            return Ok(Coffees[rng.Next(Coffees.Length)]);
        }
    }
}