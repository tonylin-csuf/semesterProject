using EventManagement.Api.Models;

namespace EventManagement.Api.Services
{
    public class EventService : IEventService
    {
        private static List<Event> Events = new List<Event>
        {
            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Tech Conference 2026",
                Description="A conference about modern software developmet",
                StartDateTime = new DateTime(2026,3,01,9,0,0),
                EndDateTime = new DateTime(2026,3,01,17,0,0),
                Location = "Seattle, WA",
                Capacity = 500
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Back End Architecture Meetup",
                Description="Like minded developer discuss modren Architecture.",
                StartDateTime = new DateTime(2026,2,20,9,0,0),
                EndDateTime = new DateTime(2026,2,20,11,0,0),
                Location = "Fullerton, CA",
                Capacity = 100
            }

        };

        public Event CreateEvent(Event input)
        {
            var newEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = input.Title,
                Description = input.Description,
                StartDateTime = input.StartDateTime,
                EndDateTime = input.EndDateTime,
                Location = input.Location,
                Capacity = input.Capacity
            };

            Events.Add(newEvent);
            return newEvent;
        }

        public Event? GetEventById(Guid id)
        {
            var _event = Events.FirstOrDefault(s => s.Id == id);
            return _event;
        }

        public List<Event> GetEvents()
        {
            return Events;
        }
    }
}