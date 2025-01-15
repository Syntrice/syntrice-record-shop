using Microsoft.IdentityModel.Tokens;
using RecordShop.Model;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public class GenericService<TIdentifiable> : IGenericService<TIdentifiable> where TIdentifiable : class, IIdentifiable
    {
        private readonly IGenericRepository<TIdentifiable> _repository;

        public GenericService(IGenericRepository<TIdentifiable> repository)
        {
            _repository = repository;
        }

        public ServiceResponse DeleteEntityById(int id)
        {
            TIdentifiable? entity = _repository.DeleteEntityById(id);

            if (entity == null)
            {
                return new ServiceResponse(ServiceResponseType.NotFound, $"{typeof(TIdentifiable).Name} with id {id} not found in repository.");
            }

            _repository.Save();

            return new ServiceResponse(ServiceResponseType.Success, null);
        }

        public ServiceObjectResponse<List<TIdentifiable>> GetEntities()
        {
            var entities = _repository.GetEntities();

            if (entities.IsNullOrEmpty())
            {
                return new ServiceObjectResponse<List<TIdentifiable>>(ServiceResponseType.NotFound, $"No {typeof(TIdentifiable).Name} entities found in repository.", null);
            }

            return new ServiceObjectResponse<List<TIdentifiable>>(ServiceResponseType.Success, null, entities.ToList());

        }

        public ServiceObjectResponse<TIdentifiable> GetEntityById(int id)
        {
            var entity = _repository.GetEntityById(id);

            if (entity == null)
            {
                return new ServiceObjectResponse<TIdentifiable>(ServiceResponseType.NotFound, $"{typeof(TIdentifiable).Name} with id {id} not found in repository.", null);
            }

            return new ServiceObjectResponse<TIdentifiable>(ServiceResponseType.Success, null, entity);
        }

        public ServiceObjectResponse<TIdentifiable> InsertEntity(TIdentifiable entity)
        {
            var idFunction = _repository.InsertEntity(entity);

            _repository.Save();

            entity.Id = idFunction.Invoke(); // update id from function, after first saving db

            return new ServiceObjectResponse<TIdentifiable>(ServiceResponseType.Success, null, entity);
        }

        public ServiceResponse UpdateEntity(TIdentifiable entity)
        {
            var updatedEntity = _repository.UpdateEntity(entity);

            if (updatedEntity == null)
            {
                return new ServiceResponse(ServiceResponseType.NotFound, $"{typeof(TIdentifiable).Name} with id {entity.Id} not found in repository.");
            }

            _repository.Save();

            return new ServiceResponse(ServiceResponseType.Success, null);

        }
    }
}
