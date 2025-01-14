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
            throw new NotImplementedException();
        }

        public ServiceObjectResponse<List<TEntity>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public ServiceObjectResponse<TEntity> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceObjectResponse<TEntity> InsertEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse UpdateEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
