using AutoMapper;
using RecordShop.Model;
using RecordShop.Repositories;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class RecordsService : GenericMappingService<Record, RecordDTO>, IRecordsService
    {
        public RecordsService(IRecordsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
