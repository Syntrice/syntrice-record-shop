using AutoMapper;
using RecordShop.Model.ArtistModel;
using RecordShop.Repositories;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class ArtistsService : GenericMappingService<Artist, ArtistGetDTO, ArtistInsertDTO, ArtistUpdateDTO>, IArtistsService
    {
        public ArtistsService(IArtistsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
