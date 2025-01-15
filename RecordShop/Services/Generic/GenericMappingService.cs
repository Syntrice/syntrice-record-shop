using RecordShop.Model;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public class GenericMappingService<TEntity, TDTO> : IGenericMappingService<TEntity, TDTO> where TEntity : class, IIdentifiable where TDTO : class, IIdentifiable
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericMappingService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public ServiceResponse DeleteEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceObjectResponse<List<TDTO>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public ServiceObjectResponse<TDTO> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceObjectResponse<TDTO> InsertEntity(TDTO entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse UpdateEntity(TDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
