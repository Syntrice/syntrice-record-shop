using AutoMapper;
using RecordShop.Model.RecordModel;

namespace RecordShop.Model.MappingProfiles
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
