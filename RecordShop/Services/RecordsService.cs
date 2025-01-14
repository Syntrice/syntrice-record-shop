using RecordShop.Model;
using RecordShop.Repositories;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class RecordsService : GenericService<Record>, IRecordsService
    {
        public RecordsService(IGenericRepository<Record> repository) : base(repository)
        {
        }
    }
}
