using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TeaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeaController : ControllerBase
    {
        private static readonly string[] Teas = new[]
        {
            "Ur tea is: Green", "Ur tea is: Peppermint", "Ur tea is: Earl Grey",
             "Ur tea is: English Breakfast", "Ur tea is: Camomile"
        };

    
        [HttpGet]
        public ActionResult Get()
        {
            var rng = new Random();
            
            return Ok(Teas[rng.Next(Teas.Length)]);
        }
    }
}