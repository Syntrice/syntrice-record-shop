
using RecordShop.Model;

namespace RecordShop.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        private readonly RecordShopDbContext _dbContext;

        public GenericRepository(RecordShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T? DeleteItemById(int id)
        {
            throw new NotImplementedException();
        }

        public T? GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetItems()
        {
            throw new NotImplementedException();
        }

        public T InsertItem(T item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public T? UpdateItem(T item)
        {
            throw new NotImplementedException();
        }
    }
}
