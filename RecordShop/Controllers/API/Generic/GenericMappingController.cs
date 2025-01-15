using Microsoft.AspNetCore.Mvc;
using RecordShop.Model;
using RecordShop.Services.Generic;
using RecordShop.Services.Response;

namespace RecordShop.Controllers.API.Generic
{
    public class GenericMappingController<TEntity, TGetDTO, TInsertDTO, TUpdateDTO> : ControllerBase
        where TEntity : class, IIdentifiable
        where TGetDTO : class, IIdentifiable
        where TInsertDTO : class, IIdentifiable
        where TUpdateDTO : class, IIdentifiable
    {
        private readonly IGenericMappingService<TEntity, TGetDTO, TInsertDTO, TUpdateDTO> _genericService;

        public GenericMappingController(IGenericMappingService<TEntity, TGetDTO, TInsertDTO, TUpdateDTO> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _genericService.GetEntities();

            switch (result.ResponseType)
            {
                case ServiceResponseType.NotFound:
                    return NotFound(result.Message);
                case ServiceResponseType.Success:
                    return Ok(result.Value);
                default:
                    return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _genericService.GetEntityById(id); 

            switch (result.ResponseType)
            {
                case ServiceResponseType.NotFound:
                    return NotFound(result.Message);
                case ServiceResponseType.Success:
                    return Ok(result.Value);
                default:
                    return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(TInsertDTO entity)
        {
            var result = _genericService.InsertEntity(entity);

            switch (result.ResponseType)
            {
                case ServiceResponseType.Success:
                    return Created(result.Value.ToString(), entity);
                default:
                    return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _genericService.DeleteEntityById(id);

            switch (result.ResponseType)
            {
                case ServiceResponseType.NotFound:
                    return NotFound(result.Message);
                case ServiceResponseType.Success:
                    return NoContent();
                default:
                    return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TUpdateDTO entity)
        {
            var result = _genericService.UpdateEntity(id, entity);

            switch (result.ResponseType)
            {
                case ServiceResponseType.NotFound:
                    return NotFound(result.Message);
                case ServiceResponseType.Success:
                    return NoContent();
                default:
                    return BadRequest();
            }
        }
    }
}
