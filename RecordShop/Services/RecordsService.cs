using RecordShop.Repository;

namespace RecordShop.Services
{
    public class RecordsService : IRecordService
    {
        private readonly IRecordsRepository _recordRepository;

        public RecordsService(IRecordsRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }
    }
}
