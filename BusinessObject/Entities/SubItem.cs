using BusinessObject.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entities
{
    public class SubItem : BaseEntity
    {
        public Guid ItemId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public Status? Status { get; set; }

        public Priority? Priority { get; set; }

        [ForeignKey(nameof(ItemId))]
        public ToDoItem? Item { get; set; }
    }
}
