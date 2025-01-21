using RecordShop.Model.RecordModel;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public interface IRecordsService : IGenericCRUDService<Record, RecordGetDTO, RecordInsertDTO, RecordUpdateDTO>
    {
    }
}
