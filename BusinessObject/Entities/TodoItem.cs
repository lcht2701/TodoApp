using BusinessObject.Constants;

namespace BusinessObject.Entities
{
    public class ToDoItem : BaseEntity
    {
        public ToDoItem()
        {
            SubTasks = new HashSet<SubItem>();
        }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueBy { get; set; }

        public Status? Status { get; set; }

        public Priority? Priority { get; set; }

        public DateTime? CompletedAt { get; set; }

        public virtual ICollection<SubItem> SubTasks { get; set; }
    }
}
