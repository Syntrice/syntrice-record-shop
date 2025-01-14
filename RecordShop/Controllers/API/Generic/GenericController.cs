using Microsoft.AspNetCore.Mvc;
using RecordShop.Model;
using RecordShop.Services.Generic;

namespace RecordShop.Controllers.API.Generic
{
    public class GenericController<TEntity> : ControllerBase where TEntity : class, IEntity
    {
        private readonly IGenericService<TEntity> _genericService;

        public GenericController(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post(Genre genre)
        {
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Genre genre)
        {
            return BadRequest();
        }
    }
}
