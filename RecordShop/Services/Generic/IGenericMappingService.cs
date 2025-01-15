using RecordShop.Model;

namespace RecordShop.Services.Generic
{
    public interface IGenericMappingService<TEntity, TDTO> : IGenericService<TDTO> where TEntity : class, IIdentifiable where TDTO : class, IIdentifiable
    {
    }
}
