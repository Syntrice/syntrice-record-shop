using Microsoft.EntityFrameworkCore;
using RecordShop.Model;
using RecordShop.Model.Database;

namespace RecordShop.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly RecordShopDbContext _dbContext;

        public GenericRepository(RecordShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Deletes the entity with the given id from the repository.
        /// </summary>
        /// <returns>The entity deleted from the databse. Will return null if no entity found with given id.</returns>
        public TEntity? DeleteEntityById(int id)
        {
            TEntity? entity = _dbContext.Set<TEntity>().Find(id); // Check if entity exists
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
            return entity;
        }

        /// <summary>
        /// Gets the entity with the given id from the repository.
        /// </summary>
        /// <returns>The found entity. Will return null if no entity found with given id.</returns>
        public TEntity? GetEntityById(int id)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Gets all entities in the repository.
        /// </summary>
        public IEnumerable<TEntity> GetEntities()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        /// <summary>
        /// Inserts an entity into the repository.
        /// </summary>
        /// <param name="entity">The entity to add to the repository</param>
        /// <returns>A function which can be invokes to retrieve the entity id value. 
        /// This can be called after saving the repository, to get an automatically assigned id for example.</returns>
        public Func<int> InsertEntity(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return () => entity.Id;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates the given entity according to its id value.
        /// </summary>
        /// <param name="entity">The entity to update. The id value will be used to match to an existing entity.</param>
        /// <returns>The updated entity. Will return null if no entity found with the given id.</returns>
        public TEntity? UpdateEntity(TEntity entity)
        {
            TEntity? existingEntity = _dbContext.Set<TEntity>().Find(entity.Id); // Check if entity exists

            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).State = EntityState.Modified;
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            }

            return existingEntity;
        }
    }
}
