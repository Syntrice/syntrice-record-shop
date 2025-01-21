using RecordShop.Model;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public interface IGenericNonMappingService<TEntity> where TEntity : class, IEntity
    {
        // Create
        public ServiceObjectResponse<int> InsertEntity(TEntity entity);

        // Read
        public ServiceObjectResponse<List<TEntity>> GetEntities();

        public ServiceObjectResponse<TEntity> GetEntityById(int id);

        // Update
        public ServiceResponse UpdateEntity(int id, TEntity entity);

        // Delete
        public ServiceResponse DeleteEntityById(int id);
    }
}
