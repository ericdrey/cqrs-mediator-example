namespace cqrs_mediator_api_example.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsCompleted { get; set; }
        public string? Secret { get; set; }
    }
}
