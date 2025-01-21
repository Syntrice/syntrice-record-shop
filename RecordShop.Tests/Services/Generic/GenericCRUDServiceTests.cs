using AutoMapper;
using FluentAssertions;
using Moq;
using RecordShop.Model;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Generic;
using RecordShop.Services.Response;
using RecordShop.Tests.Utility;

namespace RecordShop.Tests.Services.Generic
{
    public abstract class GenericCRUDServiceTests<TEntity, TGetDTO, TInsertDTO, TUpdateDTO> 
        where TEntity : class, IEntity, new()
        where TGetDTO : class, IGetDTO, new()
        where TInsertDTO : class, IInsertDTO, new()
        where TUpdateDTO : class, IUpdateDTO, new()
    {
        private Mock<IGenericCRUDRepository<TEntity>> _repoMock = null!;
        private Mock<IMapper> _mapperMock = null!;
        private IGenericCRUDService<TEntity, TGetDTO, TInsertDTO, TUpdateDTO> _service = null!;

        [SetUp]
        protected virtual void Init()
        {
            _repoMock = new Mock<IGenericCRUDRepository<TEntity>>();
            _mapperMock = new Mock<IMapper>();
            _service = new GenericCRUDService<TEntity, TGetDTO, TInsertDTO, TUpdateDTO>(_repoMock.Object, _mapperMock.Object);
        }

        [Test]
        public virtual void DeleteEntityById_ShouldCallAppropriateRepoMethods([Range(0, 10, 2)] int id)
        {
            // ARRANGE
            var mockEntity = new TEntity() { Id = id };
            _repoMock.Setup(x => x.DeleteEntityById(id)).Returns(mockEntity);

            // ACT
            _service.DeleteEntityById(id);

            // ASSERT
            _repoMock.Verify(x => x.DeleteEntityById(id), Times.Once);
            _repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Test]
        public virtual void DeleteEntityById_WhenEntityFound_ShouldReturnSuccess()
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new TEntity() { Id = id };
            _repoMock.Setup(x => x.DeleteEntityById(id)).Returns(mockEntity);

            // ACT
            var response = _service.DeleteEntityById(id);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public virtual void DeleteEntityById_WhenEntityNotFound_ShouldReturnNotFound()
        {
            // ARRANGE
            int id = 1;
            _repoMock.Setup(x => x.DeleteEntityById(id)).Returns(() => null);

            // ACT
            var response = _service.DeleteEntityById(id);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.NotFound);
        }

        [Test]
        public virtual void GetEntities_ShouldCallAppropriateRepoMethods()
        {
            // ACT
            _service.GetEntities();

            // ASSERT
            _repoMock.Verify(x => x.GetEntities(), Times.Once);
        }

        [Test]
        public virtual void GetEntities_WhenEntitiesExist_ShouldCallMapMethodOnEntities()
        {
            // ARRANGE
            var mockEntities = new List<TEntity>()
            {
                new TEntity() { Id = 1 },
                new TEntity() { Id = 2 },
                new TEntity() { Id = 3 }
            };

            _repoMock.Setup(x => x.GetEntities()).Returns(mockEntities);

            // ACT
            _service.GetEntities();

            // ASSERT
            _mapperMock.Verify(x => x.Map<List<TGetDTO>>(mockEntities), Times.Once);
        }


        [Test]
        public virtual void GetEntities_WhenEntitiesExist_ShouldReturnSuccess()
        {
            // ARRANGE
            var mockEntities = new List<TEntity>()
            {
                new TEntity() { Id = 1 },
                new TEntity() { Id = 2 },
                new TEntity() { Id = 3 }
            };

            _repoMock.Setup(x => x.GetEntities()).Returns(mockEntities);

            // ACT
            var response = _service.GetEntities();

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public virtual void GetEntities_WhenEntitiesExist_ShouldReturnMappedEntities()
        {
            // ARRANGE
            var mockEntities = new List<TEntity>()
            {
                new TEntity() { Id = 1 },
                new TEntity() { Id = 2 },
                new TEntity() { Id = 3 }
            };

            // ARRANGE
            var mapped = new List<TGetDTO>()
            {
                new TGetDTO() { Id = 1 },
                new TGetDTO() { Id = 2 },
                new TGetDTO() { Id = 3 }
            };

            _repoMock.Setup(x => x.GetEntities()).Returns(mockEntities);
            _mapperMock.Setup(x => x.Map<List<TGetDTO>>(mockEntities)).Returns(mapped);

            // ACT
            var response = _service.GetEntities();

            // ASSERT
            response.Value.Should().BeEquivalentTo(mapped);
        }

        [Test]
        public virtual void GetEntities_WhenEntitiesDoNotExist_ShouldReturnNotFound()
        {
            // ARRANGE
            _repoMock.Setup(x => x.GetEntities()).Returns(() => []);

            // ACT
            var response = _service.GetEntities();

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.NotFound);
        }


        [Test]
        public virtual void GetEntityById_ShouldCallAppropriateRepoMethods([Range(0, 10, 2)] int id)
        {
            // ACT
            _service.GetEntityById(id);

            // ASSERT
            _repoMock.Verify(x => x.GetEntityById(id), Times.Once);
        }

        [Test]
        public virtual void GetEntityById_WhenEntityExists_ShouldCallMapMethod()
        {
            // ARRANGE
            var mockEntity = new TEntity() { Id = 1 };

            _repoMock.Setup(x => x.GetEntityById(1)).Returns(mockEntity);

            // ACT
            _service.GetEntityById(1);

            // ASSERT
            _mapperMock.Verify(x => x.Map<TGetDTO>(mockEntity), Times.Once);
        }

        [Test]
        public virtual void GetEntityById_WhenEntityExists_ShouldReturnSuccess()
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new TEntity() { Id = id };
            _repoMock.Setup(x => x.GetEntityById(id)).Returns(mockEntity);

            // ACT
            var response = _service.GetEntityById(id);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public virtual void GetEntityById_WhenEntityExists_ShouldReturnMappedEntity()
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new TEntity() { Id = id };
            var mapped = new TGetDTO() { Id = id };
            _repoMock.Setup(x => x.GetEntityById(id)).Returns(mockEntity);
            _mapperMock.Setup(x => x.Map<TGetDTO>(mockEntity)).Returns(mapped);

            // ACT
            var response = _service.GetEntityById(id);

            // ASSERT
            response.Value.Should().BeEquivalentTo(mapped);
        }

        [Test]
        public virtual void GetEntityById_WhenEntityDoesNotExist_ShouldReturnNotFound()
        {
            // ARRANGE
            int id = 1;
            _repoMock.Setup(x => x.GetEntityById(id)).Returns(() => null);

            // ACT
            var response = _service.GetEntityById(id);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.NotFound);
        }

        [Test]
        public virtual void InsertEntity_ShouldCallAppropriateRepoMethods()
        {
            // ARRANGE
            var mockDTO = new TInsertDTO();
            _repoMock.Setup(x => x.InsertEntity(It.IsAny<TEntity>())).Returns(() => 11);

            // ACT
            _service.InsertEntity(mockDTO);

            // ASSERT
            _repoMock.Verify(x => x.InsertEntity(It.IsAny<TEntity>()), Times.Once);
            _repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Test]
        public virtual void InsertEntity_ShouldCallMapMethod()
        {
            // ARRANGE
            var mockDTO = new TInsertDTO();
            var mockEntity = new TEntity();
            _repoMock.Setup(x => x.InsertEntity(It.IsAny<TEntity>())).Returns(() => 11);
            _mapperMock.Setup(x => x.Map<TEntity>(mockDTO)).Returns(mockEntity);

            // ACT
            _service.InsertEntity(mockDTO);

            // ASSERT
            _mapperMock.Verify(x => x.Map<TEntity>(mockDTO), Times.Once);
        }

        [Test]
        public virtual void InsertEntity_ShouldReturnNewEntityId([Range(0, 10, 2)] int newId)
        {
            // ARRANGE
            var mockDto = new TInsertDTO();
            _repoMock.Setup(x => x.InsertEntity(It.IsAny<TEntity>())).Returns(() => newId);

            // ACT
            var response = _service.InsertEntity(mockDto);

            // ASSERT
            response.Value.Should().Be(newId);
        }

        [Test]
        public virtual void InsertEntity_ShouldReturnSuccess()
        {
            // ARRANGE
            var mockDto = new TInsertDTO();
            _repoMock.Setup(x => x.InsertEntity(It.IsAny<TEntity>())).Returns(() => 1);

            // ACT
            var response = _service.InsertEntity(mockDto);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public virtual void UpdateEntity_ShouldCallAppropriateRepoMethods()
        {
            // ARRANGE
            int id = 10;
            var mockDto = new TUpdateDTO();
            TEntity mockEntity = new TEntity() { Id = id };
            _repoMock.Setup(x => x.UpdateEntity(It.IsAny<TEntity>())).Returns(mockEntity);
            _mapperMock.Setup(x => x.Map<TEntity>(mockDto)).Returns(mockEntity);

            // ACT
            _service.UpdateEntity(id, mockDto);

            // ASSERT
            _repoMock.Verify(x => x.UpdateEntity(It.IsAny<TEntity>()), Times.Once);
            _repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Test]
        public virtual void UpdateEntity_ShouldCallMapMethod()
        {
            // ARRANGE
            int id = 10;
            var mockDTO = new TUpdateDTO();
            TEntity mockEntity = new TEntity() { Id = id };
            _repoMock.Setup(x => x.UpdateEntity(It.IsAny<TEntity>())).Returns(mockEntity);
            _mapperMock.Setup(x => x.Map<TEntity>(mockDTO)).Returns(mockEntity);

            // ACT
            _service.UpdateEntity(id, mockDTO);

            // ASSERT
            _mapperMock.Verify(x => x.Map<TEntity>(mockDTO), Times.Once);
        }

        [Test]
        public virtual void UpdateEntity_WhenEntityExists_ShouldReturnSuccess()
        {
            // ARRANGE
            int id = 10;
            var mockDTO = new TUpdateDTO();
            TEntity mockEntity = new TEntity() { Id = id };
            _repoMock.Setup(x => x.UpdateEntity(It.IsAny<TEntity>())).Returns(mockEntity);
            _mapperMock.Setup(x => x.Map<TEntity>(mockDTO)).Returns(mockEntity);

            // ACT
            var response = _service.UpdateEntity(id, mockDTO);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public virtual void UpdateEntity_WhenEntityDoesNotExist_ShouldReturnNotFound()
        {
            // ARRANGE
            int id = 10;
            var mockDTO = new TUpdateDTO();
            var mockEntity = new TEntity() { Id = id };
            _repoMock.Setup(x => x.UpdateEntity(It.IsAny<TEntity>())).Returns(() => null);
            _mapperMock.Setup(x => x.Map<TEntity>(mockDTO)).Returns(mockEntity);

            // ACT
            var response = _service.UpdateEntity(id, mockDTO);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.NotFound);
        }
    }
}
