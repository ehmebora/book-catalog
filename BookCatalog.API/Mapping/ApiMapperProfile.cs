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
            InitBookMapping();
        }

        private void InitBookMapping()
        {
            CreateMap<BookDTO, CreateBook>().ReverseMap();
            CreateMap<BookDTO, UpdateBook>().ReverseMap();
        }
    }
}
