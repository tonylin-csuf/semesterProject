using Microsoft.AspNetCore.Mvc;
using EventManagement.Api.Models;
using EventManagement.Api.Services;

namespace EventManagement.Api.Controllers
{

    [ApiController]
    [Route("api/events")]

    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationsController()
        {
            _registrationService = new RegistrationService();
        }

        [HttpPost("{id:guid}/registrations")]
        public ActionResult<Registration> CreateRegistration(Guid id, [FromBody] Registration input)
        {
            var _event = _registrationService.GetEventById(id);
            if (_event == null)
                return NotFound();

            input.EventId = id;
            input.RegisteredAt = DateTime.UtcNow;
            input.Status ??= "Pending";

            var newRegistration = _registrationService.CreateRegistration(id, input);
            return CreatedAtAction(nameof(CreateRegistration), new { id }, newRegistration);
        }

    }
}