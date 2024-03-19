using BusinessObject.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entities
{
    public class SubItem : BaseEntity
    {
        public Guid TaskId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public Status? Status { get; set; }

        public Priority? Priority { get; set; }

        [ForeignKey(nameof(TaskId))]
        public ToDoItem? Task { get; set; }
    }
}
