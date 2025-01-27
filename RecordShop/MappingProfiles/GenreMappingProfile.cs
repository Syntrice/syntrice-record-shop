using AutoMapper;
using RecordShop.Common.Models.GenreModel;

namespace RecordShop.Common.Models.MappingProfiles
{
    public class GenreMappingProfile : Profile
    {
        public GenreMappingProfile()
        {
            CreateMap<Genre, GenreGetDTO>()
                .ReverseMap();

            CreateMap<Genre, GenreInsertDTO>()
                .ReverseMap();

            CreateMap<Genre, GenreUpdateDTO>()
                .ReverseMap();
        }
    }
}
