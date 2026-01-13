// Controllers/EventParticipationsController.cs
using Microsoft.AspNetCore.Mvc;
using OfficeCalendar.Api.Models;
using OfficeCalendar.Api.Repositories;

namespace OfficeCalendar.Api.Services
{
    public class EventParticipationsService
    {
        private readonly GenericRepository<EventParticipation> _repository;

        public EventParticipationsService(GenericRepository<EventParticipation> repository)
        {
            _repository = repository;
        }

        public async Task<List<EventParticipation>> GetAllService()
        {
            var participations = await _repository.GetAllAsync();
            return participations;
        }

        public async Task<EventParticipation> GetByIdService(int id)
        {
            var participation = await _repository.GetByIdAsync(id);
            if (participation == null) throw new  KeyNotFoundException();
            return participation;
        }

        public async Task<List<EventParticipation>> GetByEventService (int eventId)
        {
            var participations = await _repository.QueryAsync(
                "SELECT * FROM event_participations WHERE event_id = @EventId",
                new { EventId = eventId }
            );
            return participations;
        }

        public async Task<(int id, EventParticipation? created)> CreateService([FromBody] EventParticipation participation)
        {
            participation.CreatedAt = DateTime.UtcNow;
            var id = await _repository.InsertAsync(participation);
            var created = await _repository.GetByIdAsync(id);
            return (id, created);
        }

        public async Task<bool> UpdateService(int id, [FromBody] EventParticipation participation)
        {
            var success = await _repository.UpdateAsync(id, participation);
            if (!success) throw new KeyNotFoundException();
            return success;
        }

        public async Task<bool> DeleteService(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success) throw new KeyNotFoundException();
            return success;
        }

        public async Task<bool> DeleteEventParticipationByUserIdAndEventIdAsyncService(int userId, int eventId)
        {
            var success = await _repository.DeleteEventParticipationAsync(userId, eventId);
            if (!success) throw new KeyNotFoundException();
            return success;
        }
    }
}