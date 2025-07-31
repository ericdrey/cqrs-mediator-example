using cqrs_mediator_api_example.Models;
using cqrs_mediator_api_example.DTO;
using MediatR;

namespace cqrs_mediator_api_example.Commands.TodoItems.Handlers
{
    public class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemCommand, TodoItemDTO>
    {
        public readonly TodoContext _context;

        public UpdateTodoItemHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItemDTO> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.TodoItems.FindAsync(request.Id);
            if (item is null) return null;

            item.Name = request.Name;
            item.IsCompleted = request.IsCompleted;
            item.Secret = "New secret value!";

            await _context.SaveChangesAsync();

            return new TodoItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                IsCompleted = item.IsCompleted
            };
        }
    }
}
