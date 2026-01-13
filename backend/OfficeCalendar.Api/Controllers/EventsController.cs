// Controllers/EventsController.cs

using Microsoft.AspNetCore.Mvc;
using OfficeCalendar.Api.Models;
using OfficeCalendar.Api.Models.DTOs;
using OfficeCalendar.Api.Repositories;
using System.Security.Claims;
using OfficeCalendar.Api.Services;
using Dapper;
using Npgsql;

namespace OfficeCalendar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventsService _service;
        private readonly IConfiguration _configuration;

        public EventsController(EventsService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventWithRoomDto>>> GetAll()
        {
            var eventWithRoomDtos = await _service.GetAllService();
            return Ok(eventWithRoomDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventWithRoomDto>> GetById(int id)
        {
            var eventWithRoomDtos = await _service.GetByIdService(id);
            return Ok(eventWithRoomDtos);
        }

        [HttpPost]
        public async Task<ActionResult<Event>> Create([FromBody] Event evt)
        {
            var (id, created) = await _service.CreateService(evt, User);
            return CreatedAtAction(nameof(GetById), new { id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Event evt)
        {
            try
            {
                var success = await _service.UpdateService(id, evt);
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
                var evt = await _service.DeleteService(id);
                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}