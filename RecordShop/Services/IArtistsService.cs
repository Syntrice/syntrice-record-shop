using RecordShop.Model.ArtistModel;
using RecordShop.Model.GenreModel;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public interface IArtistsService : IGenericMappingService<Artist, ArtistGetDTO, ArtistInsertDTO, ArtistUpdateDTO>
    {
    }
}
