using ClientBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly MxchaziContext _context;

        public EventController(ILogger<EventController> logger, MxchaziContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{asdat:alpha}"), Authorize]
        public IActionResult Test(string asdat)
        {
            var a = asdat;
            return new OkObjectResult(a);
        }

        [HttpGet("{id:int}"), Authorize]
        public IActionResult Get(int id)
        {
            // Retrieve data from database or other source
            var eventData = _context.Events.FirstOrDefault(e => e.Id == id);
            if (eventData == null)
            {
                return NotFound();
            }
            return Ok(eventData);
        }

        [HttpGet("AllEvents"), Authorize]
        public IActionResult GetEvents()
        {
            var events = _context.Events.ToList();
            return Ok(events);
        }

        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Event eventData)
        {
            // Process the posted data and return a response
            var response = new { message = "Event created successfully." };
            return Ok(response);
        }
    }
}