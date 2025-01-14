using Microsoft.IdentityModel.Tokens;
using RecordShop.Model;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class, IEntity
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
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

        public ServiceObjectResponse<TEntity> InsertEntity(TEntity entity)
        {
            var idFunction = _repository.InsertEntity(entity);

            _repository.Save();

            entity.Id = idFunction.Invoke(); // update id from function, after first saving db

            return new ServiceObjectResponse<TEntity>(ServiceResponseType.Success, null, entity);
        }

        public ServiceResponse UpdateEntity(TEntity entity)
        {
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
