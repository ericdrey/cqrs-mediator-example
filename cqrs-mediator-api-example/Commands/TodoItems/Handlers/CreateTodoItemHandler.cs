using cqrs_mediator_api_example.Models;
using cqrs_mediator_api_example.DTO;
using MediatR;

namespace cqrs_mediator_api_example.Commands.TodoItems.Handlers
{
    public class CreateTodoItemHandler: IRequestHandler<CreateTodoItemCommand, TodoItemDTO>
    {
        private readonly TodoContext _context;

        public CreateTodoItemHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItemDTO> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                Name = request.Name,
                IsCompleted = request.IsCompleted,
                Secret = "This is a secret!"
            };

            _context.TodoItems.Add(entity);
            await _context.SaveChangesAsync();

            return new TodoItemDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                IsCompleted = entity.IsCompleted
            };
        }
    }
}
