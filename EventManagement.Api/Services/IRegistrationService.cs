using EventManagement.Api.Models;

namespace EventManagement.Api.Services
{
    public interface IRegistrationService
    {
        Event? GetEventById(Guid id);
        Registration CreateRegistration(Guid eventId, Registration input);
    }
}