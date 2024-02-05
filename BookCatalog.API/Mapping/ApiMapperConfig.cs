using AutoMapper;

namespace BookCatalog.API.Mapping
{
    public class ApiMapperConfig
    {
        public static readonly MapperConfiguration Configuration;

        static ApiMapperConfig()
        {
            Configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<ApiMapperProfile>();
                config.AllowNullCollections = false;
            });
            Configuration.AssertConfigurationIsValid();
            Configuration.CompileMappings();
        }

        public static IMapper CreateMapper()
        {
            return Configuration.CreateMapper();
        }

    }
}
