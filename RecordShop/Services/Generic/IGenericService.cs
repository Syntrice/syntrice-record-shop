using RecordShop.Model;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public interface IGenericService<TIdentifiable> where TIdentifiable : class, IIdentifiable
    {
        // Create
        public ServiceObjectResponse<TIdentifiable> InsertEntity(TIdentifiable entity);

        // Read
        public ServiceObjectResponse<List<TIdentifiable>> GetEntities();

        public ServiceObjectResponse<TIdentifiable> GetEntityById(int id);

        // Update
        public ServiceResponse UpdateEntity(TIdentifiable entity);

        // Delete
        public ServiceResponse DeleteEntityById(int id);
    }
}
