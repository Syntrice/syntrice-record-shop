using RecordShop.Common.Models.GenreModel;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public interface IGenresService : IGenericCRUDService<Genre, GenreGetDTO, GenreInsertDTO, GenreUpdateDTO> 

    {
    }
}
