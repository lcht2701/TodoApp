using BusinessObject.Constants;

namespace BusinessObject.DTOs.SubItems
{
    public class UpdateSubItemRequest
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public Status? Status { get; set; }

        public Priority? Priority { get; set; }
    }
}
