using BusinessObject.Constants;

namespace BusinessObject.DTOs.SubItems
{
    public class SubItemResponse
    {
        public Guid Id { get; init; }

        public Guid TaskId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public Status? Status { get; set; }

        public Priority? Priority { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
