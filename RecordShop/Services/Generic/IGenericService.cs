using RecordShop.Model;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public interface IGenericService<TEntity> where TEntity : class, IIdentifiable
    {
        // Create
        public ServiceObjectResponse<TEntity> InsertEntity(TEntity entity);

        // Read
        public ServiceObjectResponse<List<TEntity>> GetEntities();

        public ServiceObjectResponse<TEntity> GetEntityById(int id);

        // Update
        public ServiceResponse UpdateEntity(TEntity entity);

        // Delete
        public ServiceResponse DeleteEntityById(int id);
    }
}
