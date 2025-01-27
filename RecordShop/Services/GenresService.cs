using AutoMapper;
using RecordShop.Common.Models.GenreModel;
using RecordShop.Repositories;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class GenresService : GenericCRUDService<Genre, GenreGetDTO, GenreInsertDTO, GenreUpdateDTO>, IGenresService
    {
        public GenresService(IGenresRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
