using RecordShop.Repositories;

namespace RecordShop.Services
{
    public class RecordsService : IRecordsService
    {
        private readonly IRecordsRepository _recordRepository;

        public RecordsService(IRecordsRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }
    }
}
