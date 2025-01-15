using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using RecordShop.Model;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public class GenericMappingService<TEntity, TDTO> : IGenericMappingService<TEntity, TDTO> where TEntity : class, IIdentifiable where TDTO : class, IIdentifiable
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericMappingService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _mapper = mapper;
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

        public ServiceObjectResponse<List<TDTO>> GetEntities()
        {
            var entities = _repository.GetEntities();

            if (entities.IsNullOrEmpty())
            {
                return new ServiceObjectResponse<List<TDTO>>(ServiceResponseType.NotFound, $"No {typeof(TEntity).Name} entities found in repository.", null);
            }

            // MAP HERE

            return new ServiceObjectResponse<List<TDTO>>(ServiceResponseType.Success, null, /*entities.ToList()*/ null);

        }

        public ServiceObjectResponse<TDTO> GetEntityById(int id)
        {
            var entity = _repository.GetEntityById(id);

            if (entity == null)
            {
                return new ServiceObjectResponse<TDTO>(ServiceResponseType.NotFound, $"{typeof(TEntity).Name} with id {id} not found in repository.", null);
            }

            // MAP HERE

            return new ServiceObjectResponse<TDTO>(ServiceResponseType.Success, null, /*entity*/ null);
        }

        public ServiceObjectResponse<TDTO> InsertEntity(TDTO entity)
        {
            // MAP HERE

            var idFunction = _repository.InsertEntity(/*entity*/ null);

            _repository.Save();

            entity.Id = idFunction.Invoke(); // update id from function, after first saving db

            return new ServiceObjectResponse<TDTO>(ServiceResponseType.Success, null, entity);
        }

        public ServiceResponse UpdateEntity(TDTO entity)
        {
            // MAP HERE

            var updatedEntity = _repository.UpdateEntity(/*entity*/ null);

            if (updatedEntity == null)
            {
                return new ServiceResponse(ServiceResponseType.NotFound, $"{typeof(TEntity).Name} with id {entity.Id} not found in repository.");
            }

            _repository.Save();

            return new ServiceResponse(ServiceResponseType.Success, null);
        }
    }
}
