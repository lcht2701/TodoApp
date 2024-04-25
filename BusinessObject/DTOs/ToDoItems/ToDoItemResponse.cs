namespace BusinessObject.DTOs.ToDoItems
{
    public class ToDoItemResponse
    {
        public Guid Id { get; init; }

        public string? Title { get; set; }

        public bool IsDone { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
