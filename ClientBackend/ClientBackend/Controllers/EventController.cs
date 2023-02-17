using ClientBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace ClientBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class EventController : ControllerBase
    {

        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Retrieve data from database or other source
            var eventData = new Event
            {
                Id = id,
                Name = "Event " + id,
                Location = "Location " + id,
                Country = "Country " + id,
                Capacity = new decimal[] { id * 10, id * 100 }
            };
            return Ok(eventData);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Event eventData)
        {
            // Process the posted data and return a response
            var response = new { message = "Event created successfully." };
            return Ok(response);
        }
    }
}