using RecordShop.Model;

namespace RecordShop.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        // Create
        public Func<int> InsertEntity(TEntity entity);

        // Read
        public IEnumerable<TEntity> GetEntities();

        public TEntity? GetEntityById(int id);

        // Update
        public TEntity? UpdateEntity(TEntity entity);

        // Delete
        public TEntity? DeleteEntityById(int id);

        // Save
        public void Save();
    }
}
