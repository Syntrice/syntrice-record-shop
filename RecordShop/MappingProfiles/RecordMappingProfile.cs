using AutoMapper;
using RecordShop.Common.Models.RecordModel;

namespace RecordShop.Common.Models.MappingProfiles
{
    public class RecordMappingProfile : Profile
    {
        public RecordMappingProfile()
        {
            CreateMap<Record, RecordGetDTO>()
                .ForMember(recordDTO => recordDTO.Genre, opt => opt.MapFrom(record => record.Genre.Name))
                .ForMember(recordDTO => recordDTO.Artist, opt => opt.MapFrom(record => record.Artist.Name));

            CreateMap<RecordGetDTO, Record>();

            CreateMap<Record, RecordInsertDTO>()
                .ReverseMap();

            CreateMap<Record, RecordUpdateDTO>()
                .ReverseMap();
        }
    }
}
