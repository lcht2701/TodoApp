namespace BusinessObject.DTOs.ToDoItems
{
    public class UpdateToDoItemRequest
    {
        public string? Title { get; set; }

        public bool? IsDone { get; set; }
    }
}
