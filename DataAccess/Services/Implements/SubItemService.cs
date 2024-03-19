

using AutoMapper;
using BusinessObject.DTOs.SubItems;
using BusinessObject.Entities;
using DataAccess.Repositories;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services.Implements
{
    public class SubItemService : ISubItemService
    {
        private readonly IRepositoryBase<SubItem> _subItemRepository;
        private readonly IMapper _mapper;

        public SubItemService(IRepositoryBase<SubItem> subItemRepository, IMapper mapper)
        {
            _subItemRepository = subItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubItemResponse>> Get()
        {
            var items = await _subItemRepository.GetListAsync();
            return _mapper.Map<IEnumerable<SubItemResponse>>(items);
        }

        public async Task<IEnumerable<SubItemResponse>> GetByItem(Guid itemId)
        {
            var items = await _subItemRepository.GetAsync(x => x.ItemId.Equals(itemId));
            return _mapper.Map<IEnumerable<SubItemResponse>>(items);
        }

        public async Task<SubItemResponse> GetById(Guid id)
        {
            var target = await _subItemRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            return _mapper.Map<SubItemResponse>(target);
        }

        public async Task<SubItemResponse> Add(CreateSubItemRequest request)
        {
            var result = await _subItemRepository.AddAsync(_mapper.Map<SubItem>(request));
            return _mapper.Map<SubItemResponse>(result);
        }

        public async Task<SubItemResponse> Update(Guid id, UpdateSubItemRequest request)
        {
            var target = await _subItemRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            var entity = _mapper.Map(request, target);
            var result = await _subItemRepository.UpdateAsync(entity);
            return _mapper.Map<SubItemResponse>(result);
        }

        public async Task Remove(Guid id)
        {
            var target = await _subItemRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            await _subItemRepository.RemoveAsync(target);
        }
    }
}
