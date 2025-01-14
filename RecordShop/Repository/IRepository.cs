namespace RecordShop.Repository
{
    public interface IRepository<T>
    {
        // Create
        public T InsertItem(T item);

        // Read
        public IEnumerable<T> GetItems();
        public T? GetItemById(int id);

        // Update
        public T? UpdateItem(T item);

        // Delete
        public T? DeleteItemById(int id);

        // Save
        public void Save();
    }
}
