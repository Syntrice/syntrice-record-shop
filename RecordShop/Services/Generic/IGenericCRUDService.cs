using RecordShop.Common.Models;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public interface IGenericCRUDService<TEntity, TGetDTO, TInsertDTO, TUpdateDTO>
        where TEntity : class, IEntity
        where TGetDTO : class, IGetDTO
        where TInsertDTO : class, IInsertDTO
        where TUpdateDTO : class, IUpdateDTO
    {
        // Create
        public ServiceObjectResponse<int> InsertEntity(TInsertDTO entity);

        // Read
        public ServiceObjectResponse<List<TGetDTO>> GetEntities();

        public ServiceObjectResponse<TGetDTO> GetEntityById(int id);

        // Update
        public ServiceResponse UpdateEntity(int id, TUpdateDTO entity);

        // Delete
        public ServiceResponse DeleteEntityById(int id);
    }
}
