using RecordShop.Model;
using RecordShop.Repositories;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class RecordsService : GenericService<Record>, IRecordsService
    {
        public RecordsService(IRecordsRepository repository) : base(repository)
        {
        }
    }
}
