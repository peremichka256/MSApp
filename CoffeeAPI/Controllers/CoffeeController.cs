using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeAPI.MessageServices;
using System.Text.Json;

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

        private readonly IMessageService _messageService = new MessageService();

        [HttpGet]
        public string Get()
        {
            var rng = new Random();
            var randomCoffee = Coffees[rng.Next(Coffees.Length)];
            var jsonPackage = JsonSerializer.Serialize(randomCoffee);
            _messageService.Enqueue(jsonPackage);
            return randomCoffee;
        }
    }
}