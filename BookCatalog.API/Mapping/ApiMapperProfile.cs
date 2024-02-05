using Application.Book.Commands;
using AutoMapper;
using BookCatalog.API.DTOs;
using Domain;
using Domain.Entities;

namespace BookCatalog.API.Mapping
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            InitMapping();
        }

        private void InitMapping()
        {
            CreateMap<BaseEntityDTO, BaseEntity>()
                .ReverseMap();


            CreateMap<BookDTO, Book>()
                .IncludeBase<BaseEntityDTO, BaseEntity>()
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Book, BookDTO>();


            CreateMap<CategoryDTO, Category>()
                .IncludeBase<BaseEntityDTO, BaseEntity>();

            CreateMap<Category, CategoryDTO>();

        }
    }
}
