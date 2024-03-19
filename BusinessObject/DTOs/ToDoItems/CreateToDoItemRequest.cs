using BusinessObject.Constants;

namespace BusinessObject.DTOs.ToDoItems
{
    public class CreateToDoItemRequest
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueBy { get; set; }

        public Status? Status { get; set; }

        public Priority? Priority { get; set; }
    }
}
