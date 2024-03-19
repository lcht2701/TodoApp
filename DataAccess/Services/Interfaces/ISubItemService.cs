using BusinessObject.DTOs.SubItems;

namespace DataAccess.Services.Interfaces
{
    public interface ISubItemService
    {
        Task<IEnumerable<SubItemResponse>> Get();
        Task<IEnumerable<SubItemResponse>> GetByItem(Guid itemId);
        Task<SubItemResponse> GetById(Guid id);
        Task<SubItemResponse> Add(CreateSubItemRequest request);
        Task<SubItemResponse> Update(Guid id, UpdateSubItemRequest request);
        Task Remove(Guid id);
    }
}
