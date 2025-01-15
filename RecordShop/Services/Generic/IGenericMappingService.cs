using RecordShop.Model;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public interface IGenericMappingService<TEntity, TGetDTO, TInsertDTO, TUpdateDTO>
        where TEntity : class, IIdentifiable
        where TGetDTO : class, IIdentifiable
        where TInsertDTO : class, IIdentifiable
        where TUpdateDTO : class, IIdentifiable
    {
        // Create
        public ServiceObjectResponse<TInsertDTO> InsertEntity(TInsertDTO entity);

        // Read
        public ServiceObjectResponse<List<TGetDTO>> GetEntities();

        public ServiceObjectResponse<TGetDTO> GetEntityById(int id);

        // Update
        public ServiceResponse UpdateEntity(int id, TUpdateDTO entity);

        // Delete
        public ServiceResponse DeleteEntityById(int id);
    }
}
