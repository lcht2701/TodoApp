using AutoMapper;
using BusinessObject.DTOs.SubItems;
using BusinessObject.DTOs.ToDoItems;
using BusinessObject.Entities;

namespace BusinessObject.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, CreateToDoItemRequest>().ReverseMap();
            CreateMap<ToDoItem, UpdateToDoItemRequest>().ReverseMap();
            CreateMap<ToDoItem, ToDoItemResponse>().ReverseMap();

            CreateMap<SubItem, CreateSubItemRequest>().ReverseMap();
            CreateMap<SubItem, UpdateSubItemRequest>().ReverseMap();
            CreateMap<SubItem, SubItemResponse>().ReverseMap();
        }
    }
}
