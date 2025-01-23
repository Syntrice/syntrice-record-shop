using RecordShop.Model.GenreModel;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public interface IGenresService : IGenericCRUDService<Genre, GenreGetDTO, GenreInsertDTO, GenreUpdateDTO> 

    {
    }
}
