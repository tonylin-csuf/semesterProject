using Microsoft.AspNetCore.Mvc;
using EventManagement.Api.Models;
using EventManagement.Api.Services;

namespace EventManagement.Api.Controllers
{

    [ApiController]
    [Route("api/events")]

    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController()
        {
            _eventService = new EventService();
        }

        [HttpGet]
        public ActionResult<List<Event>> GetEvents()
        {
            return Ok(_eventService.GetEvents());
        }


        [HttpGet("{id:guid}")]
        public ActionResult<Event> GetEventById(Guid id)
        {
            var _event = _eventService.GetEventById(id);

            if (_event == null)
                return NotFound();

            return Ok(_event);
        }

        [HttpPost]
        public ActionResult<Event> CreateEvent([FromBody] Event input)
        {
            var newEvent = _eventService.CreateEvent(input);
            return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, newEvent);

        }

    }
}