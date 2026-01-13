// Controllers/EventParticipationsController.cs
using Microsoft.AspNetCore.Mvc;
using OfficeCalendar.Api.Models;
using OfficeCalendar.Api.Repositories;
using OfficeCalendar.Api.Services;

namespace OfficeCalendar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventParticipationsController : ControllerBase
    {
        private readonly EventParticipationsService _service;

        public EventParticipationsController(EventParticipationsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventParticipation>>> GetAll()
        {
            var participations = await _service.GetAllService();
            return Ok(participations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventParticipation>> GetById(int id)
        {
            try
            {
                var participation = await _service.GetByIdService(id);
                return Ok(participation);
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<List<EventParticipation>>> GetByEvent(int eventId)
        {
            var participations = await _service.GetByEventService(eventId);
            return Ok(participations);
        }

        [HttpPost]
        public async Task<ActionResult<EventParticipation>> Create([FromBody] EventParticipation participation)
        {
            var (id, created) = await _service.CreateService(participation);
            return CreatedAtAction(nameof(GetById), new { id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EventParticipation participation)
        {
            try
            {
                var success = await _service.UpdateService(id, participation);
                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _service.DeleteService(id);
                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpDelete("{userId}/{eventId}")]
        public async Task<IActionResult> DeleteEventParticipationByUserIdAndEventId(int userId, int eventId)
        {
            try
            {
                var success = await _service.DeleteEventParticipationByUserIdAndEventIdAsyncService(userId, eventId);
                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }   
    }
}