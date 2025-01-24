using AutoMapper;
using RecordShop.Common.Models.RecordModel;
using RecordShop.Repositories;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class RecordsService : GenericCRUDService<Record, RecordGetDTO, RecordInsertDTO, RecordUpdateDTO>, IRecordsService
    {
        public RecordsService(IRecordsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
