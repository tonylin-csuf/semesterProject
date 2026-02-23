using EventManagement.Api.Models;

namespace EventManagement.Api.Services
{
    public class RegistrationService : IRegistrationService
    {
        private static readonly List<Event> _events = new()
        {
            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Sample Event",
                Description = "A test event",
                StartDateTime = DateTime.UtcNow.AddDays(7),
                EndDateTime = DateTime.UtcNow.AddDays(7).AddHours(2),
                Location = "TBD",
                Capacity = 100
            }
        };

        private static readonly List<Registration> _registrations = new();

        public Event? GetEventById(Guid id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public Registration CreateRegistration(Guid eventId, Registration input)
        {
            input.Id = Guid.NewGuid();
            _registrations.Add(input);
            return input;
        }
    }
}