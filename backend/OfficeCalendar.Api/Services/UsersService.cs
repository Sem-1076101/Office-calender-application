// Controllers/UsersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeCalendar.Api.Models;
using OfficeCalendar.Api.Repositories;

namespace OfficeCalendar.Api.Services
{
    public class UsersService
    {
        private readonly GenericRepository<User> _repository;

        public UsersService(GenericRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> GetAllService()
        {
            var users = await _repository.GetAllAsync();
            return users;
        }

        public async Task<User> GetByIdService(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) throw new KeyNotFoundException();
            return user;
        }

        public async Task<User> GetByEmailService(string email)
        {
            var user = await _repository.QueryFirstOrDefaultAsync(
                "SELECT * FROM users WHERE email = @Email",
                new { Email = email }
            );
            if (user == null) throw new KeyNotFoundException();
            return user;
        }

        public async Task<(int id, User user)> CreateService([FromBody] User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            var id = await _repository.InsertAsync(user);
            var created = await _repository.GetByIdAsync(id);
            return (id, created);
        }

        public async Task<bool> UpdateService(int id, [FromBody] User user)
        {
            var success = await _repository.UpdateAsync(id, user);
            if (!success) throw new KeyNotFoundException();
            return success;
        }

        public async Task<bool> DeleteService(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success) throw new KeyNotFoundException();
            return success;
        }
    }
}