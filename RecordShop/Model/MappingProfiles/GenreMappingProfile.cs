using AutoMapper;
using RecordShop.Model.GenreModel;
using RecordShop.Model.RecordModel;

namespace RecordShop.Model.MappingProfiles
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
