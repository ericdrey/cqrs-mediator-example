namespace cqrs_mediator_api_example.DTO
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
