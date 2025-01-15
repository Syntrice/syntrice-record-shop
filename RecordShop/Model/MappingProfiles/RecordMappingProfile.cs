using AutoMapper;
using RecordShop.Model.RecordModel;

namespace RecordShop.Model.MappingProfiles
{
    public class RecordMappingProfile : Profile
    {
        public RecordMappingProfile()
        {
            CreateMap<Record, RecordGetDTO>()
                .ForMember(RecordDTO => RecordDTO.Genre, opt => opt.MapFrom(Record => Record.Genre.Name))
                .ReverseMap();

            CreateMap<Record, RecordInsertDTO>()
                .ReverseMap();

            CreateMap<Record, RecordUpdateDTO>()
                .ReverseMap();
        }
    }
}
