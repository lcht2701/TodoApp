namespace BusinessObject.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string? Title { get; set; }

        public bool? IsDone { get; set; }
    }
}
