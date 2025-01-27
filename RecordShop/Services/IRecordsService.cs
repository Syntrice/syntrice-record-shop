using RecordShop.Common.Models.RecordModel;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public interface IRecordsService : IGenericCRUDService<Record, RecordGetDTO, RecordInsertDTO, RecordUpdateDTO>
    {
    }
}
