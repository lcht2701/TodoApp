using BusinessObject.Constants;
using BusinessObject.DTOs.SubItems;

namespace BusinessObject.DTOs.ToDoItems
{
    public class ToDoItemResponse
    {
        public Guid Id { get; init; }
        
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueBy { get; set; }

        public Status? Status { get; set; }

        public Priority? Priority { get; set; }

        public DateTime? CompletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public IEnumerable<SubItemResponse>? SubItems { get; set; }
    }
}
