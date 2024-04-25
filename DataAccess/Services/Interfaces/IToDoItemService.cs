using BusinessObject.DTOs.ToDoItems;

namespace DataAccess.Services.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItemResponse>> GetList();
        Task<ToDoItemResponse> GetById(Guid id);
        Task<ToDoItemResponse> Add(CreateToDoItemRequest request);
        Task<ToDoItemResponse> Update(Guid id, UpdateToDoItemRequest request);
        Task<ToDoItemResponse> CheckIsDone(Guid id);
        Task Remove(Guid id);
    }
}
