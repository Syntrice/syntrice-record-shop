using RecordShop.Model.RecordModel;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public interface IRecordsService : IGenericMappingService<Record, RecordGetDTO, RecordInsertDTO, RecordUpdateDTO>
    {
    }
}
