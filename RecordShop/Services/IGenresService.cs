using RecordShop.Model.GenreModel;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public interface IGenresService : IGenericMappingService<Genre, GenreGetDTO, GenreInsertDTO, GenreUpdateDTO> 

    {
    }
}
