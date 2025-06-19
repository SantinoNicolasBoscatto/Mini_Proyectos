using AutoMapper;
using NotesApp.Domain;
using NotesApp.Models.Domain;
using System.Linq.Expressions;

namespace NotesApp.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<StatusModel, Status>().ReverseMap();
            CreateMap<PriorityModel, Priority>().ReverseMap();

            CreateMap<Note, NoteModel>().ReverseMap();
            CreateMap<ToDoTask, ToDoTaskModel>().ReverseMap();
            CreateMap<Expression<Func<Note, bool>>, Expression<Func<NoteModel, bool>>>().ReverseMap();
        }
    }
}
