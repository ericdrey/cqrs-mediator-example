using cqrs_mediator_api_example.DTO;
using cqrs_mediator_api_example.Models;
using Microsoft.EntityFrameworkCore;

namespace cqrs_mediator_api_example.Services
{
    public class TodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItemDTO>> GetAllAsync()
        {
            var todoItems = await _context.TodoItems.ToListAsync();

            return todoItems.Select(ItemToDTO);
        }

        public async Task<TodoItemDTO?> GetByIdAsync(long id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            return item is null ? null : ItemToDTO(item);
        }

        public async Task<TodoItemDTO?> UpdateAsync(long id, TodoItemDTO dto)
        {
            if (id != dto.Id) return null;

            var entity = await _context.TodoItems.FindAsync(id);
            if (entity == null) return null;

            entity.Name = dto.Name;
            entity.IsCompleted = dto.IsCompleted;

            await _context.SaveChangesAsync();
            return ItemToDTO(entity);
        }

        public async Task<TodoItemDTO> CreateAsync(TodoItemDTO dto)
        {
            var entity = new TodoItem
            {
                Name = dto.Name,
                IsCompleted = dto.IsCompleted
            };

            _context.TodoItems.Add(entity);
            await _context.SaveChangesAsync();

            return ItemToDTO(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.TodoItems.FindAsync(id);
            if (entity == null) return false;

            _context.TodoItems.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private static TodoItemDTO ItemToDTO(TodoItem item) => new()
        {
            Id = item.Id,
            Name = item.Name,
            IsCompleted = item.IsCompleted
        };
    }
}
