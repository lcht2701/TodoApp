using BusinessObject.Constants;
using BusinessObject.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.DTOs.SubItems
{
    public class CreateSubItemRequest
    {
        public Guid TaskId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public Status? Status { get; set; }

        public Priority? Priority { get; set; }
    }
}
