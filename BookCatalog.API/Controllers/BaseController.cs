using AutoMapper;
using BookCatalog.API.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper Mapper = ApiMapperConfig.CreateMapper();
    }
}
