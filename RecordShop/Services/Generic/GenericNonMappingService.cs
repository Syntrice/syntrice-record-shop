using Microsoft.IdentityModel.Tokens;
using RecordShop.Model;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public class GenericNonMappingService<TEntity> : IGenericMappingService<TEntity, TEntity, TEntity, TEntity> 
        where TEntity : class, IIdentifiable
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericNonMappingService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public ServiceResponse DeleteEntityById(int id)
        {
            TEntity? entity = _repository.DeleteEntityById(id);

            if (entity == null)
            {
                return new ServiceResponse(ServiceResponseType.NotFound, $"{typeof(TEntity).Name} with id {id} not found in repository.");
            }

            _repository.Save();

            return new ServiceResponse(ServiceResponseType.Success, null);
        }

        public ServiceObjectResponse<List<TEntity>> GetEntities()
        {
            var entities = _repository.GetEntities();

            if (entities.IsNullOrEmpty())
            {
                return new ServiceObjectResponse<List<TEntity>>(ServiceResponseType.NotFound, $"No {typeof(TEntity).Name} entities found in repository.", null);
            }

            return new ServiceObjectResponse<List<TEntity>>(ServiceResponseType.Success, null, entities.ToList());

        }

        public ServiceObjectResponse<TEntity> GetEntityById(int id)
        {
            var entity = _repository.GetEntityById(id);

            if (entity == null)
            {
                return new ServiceObjectResponse<TEntity>(ServiceResponseType.NotFound, $"{typeof(TEntity).Name} with id {id} not found in repository.", null);
            }

            return new ServiceObjectResponse<TEntity>(ServiceResponseType.Success, null, entity);
        }

        public ServiceObjectResponse<int> InsertEntity(TEntity entity)
        {
            var idFunction = _repository.InsertEntity(entity);

            _repository.Save();

            int id = idFunction.Invoke(); // update id from function, after first saving db

            return new ServiceObjectResponse<int>(ServiceResponseType.Success, null, id);
        }

        public ServiceResponse UpdateEntity(int id, TEntity entity)
        {
            entity.Id = id;
            var updatedEntity = _repository.UpdateEntity(entity);

            if (updatedEntity == null)
            {
                return new ServiceResponse(ServiceResponseType.NotFound, $"{typeof(TEntity).Name} with id {entity.Id} not found in repository.");
            }

            _repository.Save();

            return new ServiceResponse(ServiceResponseType.Success, null);

        }
    }
}
