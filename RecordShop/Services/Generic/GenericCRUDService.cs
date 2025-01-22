using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using RecordShop.Model;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Response;

namespace RecordShop.Services.Generic
{
    public class GenericCRUDService<TEntity, TGetDTO, TInsertDTO, TUpdateDTO> : IGenericCRUDService<TEntity, TGetDTO, TInsertDTO, TUpdateDTO>
        where TEntity : class, IEntity
        where TGetDTO : class, IGetDTO
        where TInsertDTO : class, IInsertDTO
        where TUpdateDTO : class, IUpdateDTO
    {
        private readonly IGenericCRUDRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericCRUDService(IGenericCRUDRepository<TEntity> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual ServiceResponse DeleteEntityById(int id)
        {
            TEntity? entity = _repository.DeleteEntityById(id);

            if (entity == null)
            {
                return new ServiceResponse(ServiceResponseType.NotFound, $"{typeof(TEntity).Name} with id {id} not found in repository.");
            }

            _repository.Save();

            return new ServiceResponse(ServiceResponseType.Success, null);
        }

        public virtual ServiceObjectResponse<List<TGetDTO>> GetEntities()
        {
            var entities = _repository.GetEntities().ToList();

            if (entities.IsNullOrEmpty())
            {
                return new ServiceObjectResponse<List<TGetDTO>>(ServiceResponseType.NotFound, $"No {typeof(TEntity).Name} entities found in repository.", null);
            }

            var mapped = _mapper.Map<List<TGetDTO>>(entities);

            return new ServiceObjectResponse<List<TGetDTO>>(ServiceResponseType.Success, null, mapped);

        }

        public virtual ServiceObjectResponse<TGetDTO> GetEntityById(int id)
        {
            var entity = _repository.GetEntityById(id);

            if (entity == null)
            {
                return new ServiceObjectResponse<TGetDTO>(ServiceResponseType.NotFound, $"{typeof(TEntity).Name} with id {id} not found in repository.", null);
            }

            var mapped = _mapper.Map<TGetDTO>(entity);

            return new ServiceObjectResponse<TGetDTO>(ServiceResponseType.Success, null, mapped);
        }

        public virtual ServiceObjectResponse<int> InsertEntity(TInsertDTO dto)
        {
            var mapped = _mapper.Map<TEntity>(dto);

            var idFunction = _repository.InsertEntity(mapped);

            _repository.Save();

            int id = idFunction.Invoke(); // update id from function, after first saving db

            return new ServiceObjectResponse<int>(ServiceResponseType.Success, null, id);
        }

        public virtual ServiceResponse UpdateEntity(int id, TUpdateDTO dto)
        {
            var mapped = _mapper.Map<TEntity>(dto);

            mapped.Id = id;

            var updatedEntity = _repository.UpdateEntity(mapped);

            if (updatedEntity == null)
            {
                return new ServiceResponse(ServiceResponseType.NotFound, $"{typeof(TEntity).Name} with id {id} not found in repository.");
            }

            _repository.Save();

            return new ServiceResponse(ServiceResponseType.Success, null);
        }
    }
}
