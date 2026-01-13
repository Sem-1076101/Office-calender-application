// Controllers/WorkStatusController.cs

using Microsoft.AspNetCore.Mvc;
using OfficeCalendar.Api.Models;
using OfficeCalendar.Api.Repositories;

namespace OfficeCalendar.Api.Services
{
    public class ReviewService
    {
        private readonly GenericRepository<Review> _repository;
        private readonly ILogger<ReviewService> _logger;

        public ReviewService(
            GenericRepository<Review> repository,
            ILogger<ReviewService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<List<Review>> GetReviewPerEventService(
            int eventId)
        {
            _logger.LogInformation("Received request - eventId: {eventId}", eventId);

            if (eventId <= 0)
            {
                throw new ArgumentException("Valid eventId parameter is required");
            } 

            _logger.LogInformation("Querying work status for event {EventId}", eventId);

            var reviews = await _repository.QueryAsync(
                @"SELECT 
                    r.id AS Id,
                    r.user_id AS UserId,
                    r.event_id AS EventId,
                    r.text_review AS TextReview,
                    r.created_at AS CreatedAt,
                    r.updated_at AS UpdatedAt
                FROM Reviews r
                JOIN Events e ON r.event_id = e.id
                WHERE r.event_id = @EventId AND e.id = @EventId
                ORDER BY r.created_at DESC",
                new { EventId = eventId }
            );

            _logger.LogInformation("Found {Count} reviews", reviews.Count);

            return reviews;
        }
        
        [HttpGet("{id}")]
        public async Task<Review> GetByIdService(int id)
        {
            var review = await _repository.GetByIdAsync(id);
            return review;
        }

        [HttpPost]
        public async Task<(int id, Review? review)> CreateService([FromBody] CreateReviewDto dto)
        {
            var review = new Review
            {
                UserId = dto.UserId,
                EventId = dto.EventId,
                TextReview = dto.TextReview,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };

            var id = await _repository.InsertAsync(review);
            var created = await _repository.GetByIdAsync(id);

            return (id, created);
        }

        [HttpPut("{id}")]
        public async Task<(int id, bool success)> UpdateService(int id, [FromBody] CreateReviewDto dto)
        {

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException();
            existing.TextReview = dto.TextReview;
            existing.UpdatedAt = DateTime.UtcNow;

            var success = await _repository.UpdateAsync(id, existing);
            if (!success) throw new KeyNotFoundException();
            return (id, success);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteService(int id)
        {
                var success = await _repository.DeleteAsync(id);
                if (!success) throw new KeyNotFoundException();
                return success;
        }
    }

    public class CreateReviewDto
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Date { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string TextReview { get; set; } = string.Empty;
    }
}