using RecordShop.Model.ArtistModel;
using RecordShop.Model.GenreModel;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public interface IArtistsService : IGenericCRUDService<Artist, ArtistGetDTO, ArtistInsertDTO, ArtistUpdateDTO>
    {
    }
}
