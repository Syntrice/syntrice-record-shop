using AutoMapper;
using RecordShop.Model.ArtistModel;

namespace RecordShop.Model.MappingProfiles
{
    public class ArtistMappingProfile : Profile
    {
        public ArtistMappingProfile()
        {
            CreateMap<Artist, ArtistGetDTO>()
                .ReverseMap();

            CreateMap<Artist, ArtistInsertDTO>()
                .ReverseMap();

            CreateMap<Artist, ArtistUpdateDTO>()
                .ReverseMap();
        }
    }
}
