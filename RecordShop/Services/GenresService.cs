using AutoMapper;
using RecordShop.Model.GenreModel;
using RecordShop.Repositories;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class GenresService : GenericMappingService<Genre, GenreGetDTO, GenreInsertDTO, GenreUpdateDTO>, IGenresService
    {
        public GenresService(IGenresRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
