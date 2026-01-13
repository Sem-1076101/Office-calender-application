// Controllers/WorkStatusController.cs

using Microsoft.AspNetCore.Mvc;
using OfficeCalendar.Api.Models;
using OfficeCalendar.Api.Repositories;
using OfficeCalendar.Api.Services;

namespace OfficeCalendar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _service;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(
            ReviewService service,
            ILogger<ReviewController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("reviewPerEvent/{eventId}")]
        public async Task<ActionResult<List<Review>>> GetReviewPerEvent(
            [FromRoute] int? eventId)
        {
            try
            {
                var reviews = await _service.GetReviewPerEventService( eventId ?? 0 );
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting week work status");
                return StatusCode(500, new { message = "Internal server error", detail = ex.Message });
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetById(int id)
        {
            try
            {
                var review = await _service.GetByIdService(id);
                return Ok(review);
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult<Review>> Create([FromBody] CreateReviewDto dto)
        {
            try
            {
                var (id, created) = await _service.CreateService(dto);
                return CreatedAtAction(nameof(GetById), new { id }, created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating work status");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateReviewDto dto)
        {
            try
            {
                var updated = await _service.UpdateService(id, dto);
                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating work status");
                return BadRequest(new { message = ex.Message });
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting work status");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}