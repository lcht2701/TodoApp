using BusinessObject.DTOs.ToDoItems;

namespace DataAccess.Services.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItemResponse>> Get();
        Task<ToDoItemResponse> Add(CreateToDoItemRequest request);
    }
}
