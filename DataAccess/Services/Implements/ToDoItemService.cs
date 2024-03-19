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
        private readonly ISubItemService _subItemService;
        private readonly IMapper _mapper;

        public ToDoItemService(IRepositoryBase<ToDoItem> toDoItemRepository, ISubItemService subItemService, IMapper mapper)
        {
            _toDoItemRepository = toDoItemRepository;
            _subItemService = subItemService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ToDoItemResponse>> Get()
        {
            var items = await _toDoItemRepository.GetListAsync();
            return _mapper.Map<IEnumerable<ToDoItemResponse>>(items);
        }

        public async Task<ToDoItemResponse> GetById(Guid id)
        {
            var target = await _toDoItemRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            var subItems = await _subItemService.GetByItem(target.Id);
            var result = _mapper.Map<ToDoItemResponse>(target);
            result.SubItems = subItems;
            return result;
        }

        public async Task<ToDoItemResponse> Add(CreateToDoItemRequest request)
        {
            var result = await _toDoItemRepository.AddAsync(_mapper.Map<ToDoItem>(request));
            return _mapper.Map<ToDoItemResponse>(result);
        }

        public async Task<ToDoItemResponse> Update(Guid id, UpdateToDoItemRequest request)
        {
            var target = await _toDoItemRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            var entity = _mapper.Map(request, target);
            var result = await _toDoItemRepository.UpdateAsync(entity);
            return _mapper.Map<ToDoItemResponse>(result);
        }

        public async Task Remove(Guid id)
        {
            var target = await _toDoItemRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            await _toDoItemRepository.RemoveAsync(target);
        }

    }
}
