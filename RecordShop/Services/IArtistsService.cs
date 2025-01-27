using RecordShop.Common.Models.ArtistModel;
using RecordShop.Common.Models.GenreModel;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public interface IArtistsService : IGenericCRUDService<Artist, ArtistGetDTO, ArtistInsertDTO, ArtistUpdateDTO>
    {
    }
}
