using BusinessObject.DTOs.ToDoItems;
using BusinessObject.Entities;
using DataAccess.Repositories;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Implements
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IRepositoryBase<ToDoItem> _toDoItemRepository;

        public ToDoItemService(IRepositoryBase<ToDoItem> toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task<IEnumerable<ToDoItemResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<ToDoItemResponse> Add(CreateToDoItemRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
