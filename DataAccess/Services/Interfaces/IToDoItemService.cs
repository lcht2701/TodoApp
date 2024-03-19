using BusinessObject.DTOs.ToDoItems;

namespace DataAccess.Services.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItemResponse>> Get();
        Task<ToDoItemResponse> GetById(Guid id);
        Task<ToDoItemResponse> Add(CreateToDoItemRequest request);
        Task<ToDoItemResponse> Update(Guid id, UpdateToDoItemRequest request);
        Task Remove(Guid id);
    }
}
