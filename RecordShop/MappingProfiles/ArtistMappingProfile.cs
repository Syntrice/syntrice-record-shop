using AutoMapper;
using RecordShop.Common.Models.ArtistModel;

namespace RecordShop.Common.Models.MappingProfiles
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
