using AutoMapper;

namespace RecordShop.Model.MappingProfiles
{
    public class RecordMappingProfile : Profile
    {
        public RecordMappingProfile()
        {
            CreateMap<Record, RecordDTO>()
                .ForMember(RecordDTO => RecordDTO.Genre, opt => opt.MapFrom(Record => Record.Genre.Name))
                .ReverseMap();
        }
    }
}
