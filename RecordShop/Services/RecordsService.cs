using AutoMapper;
using RecordShop.Model.RecordModel;
using RecordShop.Repositories;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class RecordsService : GenericMappingService<Record, RecordGetDTO, RecordGetDTO, RecordGetDTO>, IRecordsService
    {
        public RecordsService(IRecordsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
