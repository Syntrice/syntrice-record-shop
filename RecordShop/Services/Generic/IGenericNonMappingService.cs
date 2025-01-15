using RecordShop.Model;

namespace RecordShop.Services.Generic
{
    public interface IGenericNonMappingService<TEntity> : IGenericMappingService<TEntity, TEntity, TEntity, TEntity> where TEntity : class, IIdentifiable
    {
    }
}
