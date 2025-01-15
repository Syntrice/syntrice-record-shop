using RecordShop.Model;
using RecordShop.Services.Generic;

namespace RecordShop.Controllers.API.Generic
{
    public class GenericNonMappingController<TEntity> : GenericMappingController<TEntity, TEntity, TEntity, TEntity> where TEntity : class, IIdentifiable
    {
        public GenericNonMappingController(IGenericMappingService<TEntity, TEntity, TEntity, TEntity> genericService) : base(genericService)
        {
        }
    }
}
