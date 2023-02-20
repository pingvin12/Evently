using ClientBackendNoAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly MxchaziContext _context;

        public EventController(ILogger<EventController> logger, MxchaziContext context)
        {
            _logger = logger;
            _context = context;
        }

        //    / <summary>
        //    / used only for testing,
        //    / creates a database using inmemory db
        //    / uncompatible because npgsql
        //    / will need workaround see https://github.com/npgsql/efcore.pg/issues/774
        //    / </summary>
        //    / <param name = "holder" > context object used later on for appending test objects to memory</param>
        //    public eventcontroller(list<event> holder)
        //{
        //    made for testing only, will need rework to work with npgsql https://github.com/npgsql/efcore.pg/issues/774

        //   var options = new dbcontextoptionsbuilder<mxchazicontext>()
        //  .useinmemorydatabase(databasename: "mxchazidatabase")
        //  .options;

        //    _context = new mxchazicontext(options);
        //    foreach (var item in holder)
        //    {
        //        _context.events.add(new event { id = item.id, name = item.name, country = item.country, location = item.location, capacity = item.capacity });
        //    }

        //}

        // Get event on id
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var eventData = _context.Events.FirstOrDefault(e => e.Id == id);
            if (eventData == null)
            {
                return NotFound();
            }
            return Ok(eventData);
        }


        [HttpDelete("DeleteEvent")]
        public IActionResult Delete(int id)
        {
            var eventData = _context.Events.FirstOrDefault(
                x => x.Id == id);

            if (eventData == null)
            {
                _logger.LogError($"Error while deleting object with id: {id}, Error message : object does not exist.");
                return NotFound();

            }

            try
            {
                _context.Events.Remove(eventData);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while deleting object with id : {id}, Error message : {ex.Message}");
                return BadRequest(ex.Message);
            }
            return Ok(eventData);
        }

        // Returns all events
        [HttpGet("AllEvents")]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = await _context.Events.ToListAsync();
            return events;
        }

        [HttpPost]
        public IActionResult Edit([FromBody] Event eventData)
        {
            try
            {
                var item = _context.Events.FirstOrDefault(x => x.Id == eventData.Id);
                Delete(item.Id);
                Post(eventData);
                return Ok(eventData);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while modifying object : {eventData}, Error message : {ex.Message}");
                return new BadRequestResult();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Event eventData)
        {
            //
            // Validation only required for location (max 100 characters) and 
            // edge case for pk duplication is self explanatory.
            if (_context.Events.Any(x => x.Id == eventData.Id) || eventData?.Location?.Length > 100)
            {
                return new BadRequestResult();
            }
            else
            {
                // Save changes to db on change
                try
                {
                    _context.Add(eventData);
                    _context.SaveChanges();
                    return new OkObjectResult(eventData);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error while inserting object : {eventData}, Error message : {ex.Message}");
                    return new BadRequestResult();
                }
            }
        }
    }
}