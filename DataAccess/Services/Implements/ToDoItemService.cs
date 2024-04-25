using AutoMapper;
using BusinessObject.DTOs.ToDoItems;
using BusinessObject.Entities;
using DataAccess.Repositories;
using DataAccess.Services.Interfaces;

namespace DataAccess.Services.Implements
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IRepositoryBase<ToDoItem> _toDoItemRepository;
        private readonly IMapper _mapper;

        public ToDoItemService(IRepositoryBase<ToDoItem> toDoItemRepository, IMapper mapper)
        {
            _toDoItemRepository = toDoItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ToDoItemResponse>> GetList()
        {
            var items = await _toDoItemRepository.GetListAsync();
            return _mapper.Map<IEnumerable<ToDoItemResponse>>(items);
        }

        public async Task<ToDoItemResponse> GetById(Guid id)
        {
            var target = await _toDoItemRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            var result = _mapper.Map<ToDoItemResponse>(target);
            return result;
        }

        public async Task<ToDoItemResponse> Add(CreateToDoItemRequest request)
        {
            var entity = _mapper.Map<ToDoItem>(request);
            entity.IsDone = false;
            var result = await _toDoItemRepository.AddAsync(entity);
            return _mapper.Map<ToDoItemResponse>(result);
        }

        public async Task<ToDoItemResponse> Update(Guid id, UpdateToDoItemRequest request)
        {
            var target = await _toDoItemRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            var entity = _mapper.Map(request, target);
            var result = await _toDoItemRepository.UpdateAsync(entity);
            return _mapper.Map<ToDoItemResponse>(result);
        }

        public async Task<ToDoItemResponse> CheckIsDone(Guid id)
        {
            var target = await _toDoItemRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            target.IsDone = !target.IsDone;
            var result = await _toDoItemRepository.UpdateAsync(target);
            return _mapper.Map<ToDoItemResponse>(result);
        }

        public async Task Remove(Guid id)
        {
            var target = await _toDoItemRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            await _toDoItemRepository.RemoveAsync(target);
        }

    }
}
