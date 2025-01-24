using AutoMapper;
using RecordShop.Common.Models.ArtistModel;
using RecordShop.Repositories;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class ArtistsService : GenericCRUDService<Artist, ArtistGetDTO, ArtistInsertDTO, ArtistUpdateDTO>, IArtistsService
    {
        public ArtistsService(IArtistsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
