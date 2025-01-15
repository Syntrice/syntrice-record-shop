using AutoMapper;
using FluentAssertions;
using Moq;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Generic;
using RecordShop.Services.Response;
using RecordShop.Tests.Utility;

namespace RecordShop.Tests.Services.Generic
{
    public class GenericMappingServiceTests
    {
        private Mock<IGenericRepository<MockEntity>> _repoMock;
        private Mock<IMapper> _mapperMock;
        private GenericMappingService<MockEntity, MockDTO, MockDTO, MockDTO> _service;

        [SetUp]
        public void Init()
        {
            _repoMock = new Mock<IGenericRepository<MockEntity>>();
            _mapperMock = new Mock<IMapper>();

            // Mock mapping
            _mapperMock.Setup(m => m.Map<MockDTO>(It.IsAny<MockEntity>())).Returns((MockEntity src) => new MockDTO() { Id = src.Id });
            _mapperMock.Setup(m => m.Map<MockEntity>(It.IsAny<MockDTO>())).Returns((MockDTO src) => new MockEntity() { Id = src.Id });

            _mapperMock.Setup(m => m.Map<List<MockDTO>>(It.IsAny<List<MockEntity>>())).Returns((List<MockEntity> src) => src.Select(x => new MockDTO() { Id = x.Id }).ToList());
            _mapperMock.Setup(m => m.Map<List<MockEntity>>(It.IsAny<List<MockDTO>>())).Returns((List<MockDTO> src) => src.Select(x => new MockEntity() { Id = x.Id }).ToList());

            _service = new GenericMappingService<MockEntity, MockDTO, MockDTO, MockDTO>(_repoMock.Object, _mapperMock.Object);
        }

        [Test]
        public void DeleteEntityById_ShouldCallAppropriateRepoMethods([Range(0, 10, 2)] int id)
        {
            // ARRANGE
            var mockEntity = new MockEntity() { Id = id };
            _repoMock.Setup(x => x.DeleteEntityById(id)).Returns(mockEntity);

            // ACT
            _service.DeleteEntityById(id);

            // ASSERT
            _repoMock.Verify(x => x.DeleteEntityById(id), Times.Once);
            _repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Test]
        public void DeleteEntityById_WhenEntityFound_ShouldReturnSuccess()
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new MockEntity() { Id = id };
            _repoMock.Setup(x => x.DeleteEntityById(id)).Returns(mockEntity);

            // ACT
            var response = _service.DeleteEntityById(id);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public void DeleteEntityById_WhenEntityNotFound_ShouldReturnNotFound()
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
        public void GetEntities_ShouldCallAppropriateRepoMethods()
        {
            // ACT
            _service.GetEntities();

            // ASSERT
            _repoMock.Verify(x => x.GetEntities(), Times.Once);
        }

        [Test]
        public void GetEntities_WhenEntitiesExist_ShouldCallMapMethodOnEntities()
        {
            // ARRANGE
            var mockEntities = new List<MockEntity>()
            {
                new MockEntity() { Id = 1 },
                new MockEntity() { Id = 2 },
                new MockEntity() { Id = 3 }
            };

            _repoMock.Setup(x => x.GetEntities()).Returns(mockEntities);

            // ACT
            _service.GetEntities();

            // ASSERT
            _mapperMock.Verify(x => x.Map<List<MockDTO>>(mockEntities), Times.Once);
        }


        [Test]
        public void GetEntities_WhenEntitiesExist_ShouldReturnSuccess()
        {
            // ARRANGE
            var mockEntities = new List<MockEntity>()
            {
                new MockEntity() { Id = 1 },
                new MockEntity() { Id = 2 },
                new MockEntity() { Id = 3 }
            };

            _repoMock.Setup(x => x.GetEntities()).Returns(mockEntities);

            // ACT
            var response = _service.GetEntities();

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public void GetEntities_WhenEntitiesExist_ShouldReturnMappedEntities()
        {
            // ARRANGE
            var mockEntities = new List<MockEntity>()
            {
                new MockEntity() { Id = 1 },
                new MockEntity() { Id = 2 },
                new MockEntity() { Id = 3 }
            };

            // ARRANGE
            var mapped = new List<MockDTO>()
            {
                new MockDTO() { Id = 1 },
                new MockDTO() { Id = 2 },
                new MockDTO() { Id = 3 }
            };

            _repoMock.Setup(x => x.GetEntities()).Returns(mockEntities);

            // ACT
            var response = _service.GetEntities();

            // ASSERT
            response.Value.Should().BeEquivalentTo(mapped);
        }

        [Test]
        public void GetEntities_WhenEntitiesDoNotExist_ShouldReturnNotFound()
        {
            // ARRANGE
            _repoMock.Setup(x => x.GetEntities()).Returns(() => []);

            // ACT
            var response = _service.GetEntities();

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.NotFound);
        }


        [Test]
        public void GetEntityById_ShouldCallAppropriateRepoMethods([Range(0, 10, 2)] int id)
        {
            // ACT
            _service.GetEntityById(id);

            // ASSERT
            _repoMock.Verify(x => x.GetEntityById(id), Times.Once);
        }

        [Test]
        public void GetEntityById_WhenEntityExists_ShouldCallMapMethod()
        {
            // ARRANGE
            var mockEntity = new MockEntity() { Id = 1 };

            _repoMock.Setup(x => x.GetEntityById(1)).Returns(mockEntity);

            // ACT
            _service.GetEntityById(1);

            // ASSERT
            _mapperMock.Verify(x => x.Map<MockDTO>(mockEntity), Times.Once);
        }

        [Test]
        public void GetEntityById_WhenEntityExists_ShouldReturnSuccess()
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new MockEntity() { Id = id };
            _repoMock.Setup(x => x.GetEntityById(id)).Returns(mockEntity);

            // ACT
            var response = _service.GetEntityById(id);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public void GetEntityById_WhenEntityExists_ShouldReturnMappedEntity()
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new MockEntity() { Id = id };
            var mapped = new MockDTO() { Id = id };
            _repoMock.Setup(x => x.GetEntityById(id)).Returns(mockEntity);

            // ACT
            var response = _service.GetEntityById(id);

            // ASSERT
            response.Value.Should().BeEquivalentTo(mapped);
        }

        [Test]
        public void GetEntityById_WhenEntityDoesNotExist_ShouldReturnNotFound()
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
        public void InsertEntity_ShouldCallAppropriateRepoMethods()
        {
            // ARRANGE
            MockDTO mockDTO = new MockDTO() { Id = 10 };
            _repoMock.Setup(x => x.InsertEntity(It.IsAny<MockEntity>())).Returns(() => 11);

            // ACT
            _service.InsertEntity(mockDTO);

            // ASSERT
            _repoMock.Verify(x => x.InsertEntity(It.IsAny<MockEntity>()), Times.Once);
            _repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Test]
        public void InsertEntity_ShouldCallMapMethod()
        {
            // ARRANGE
            MockDTO mockDTO = new MockDTO() { Id = 10 };
            _repoMock.Setup(x => x.InsertEntity(It.IsAny<MockEntity>())).Returns(() => 11);

            // ACT
            _service.InsertEntity(mockDTO);

            // ASSERT
            _mapperMock.Verify(x => x.Map<MockEntity>(mockDTO), Times.Once);
        }

        [Test]
        public void InsertEntity_ShouldReturnMappedInsertedEntity_WithUpdatedId([Range(0, 10, 2)] int newId)
        {
            // ARRANGE
            int id = 1;
            var mockDto = new MockDTO() { Id = id };
            var expectedResultDto = new MockDTO() { Id = newId };
            _repoMock.Setup(x => x.InsertEntity(It.IsAny<MockEntity>())).Returns(() => newId);

            // ACT
            var response = _service.InsertEntity(mockDto);

            // ASSERT
            response.Value.Should().BeEquivalentTo(expectedResultDto);
        }

        [Test]
        public void InsertEntity_ShouldReturnSuccess()
        {
            // ARRANGE
            var mockDto = new MockDTO();
            _repoMock.Setup(x => x.InsertEntity(It.IsAny<MockEntity>())).Returns(() => 1);

            // ACT
            var response = _service.InsertEntity(mockDto);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public void UpdateEntity_ShouldCallAppropriateRepoMethods()
        {
            // ARRANGE
            int id = 10;
            MockDTO mockDto = new MockDTO() { Id = id };
            MockEntity updatedMocKEntity = new MockEntity() { Id = id };
            _repoMock.Setup(x => x.UpdateEntity(It.IsAny<MockEntity>())).Returns(updatedMocKEntity);

            // ACT
            _service.UpdateEntity(id, mockDto);

            // ASSERT
            _repoMock.Verify(x => x.UpdateEntity(It.IsAny<MockEntity>()), Times.Once);
            _repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Test]
        public void UpdateEntity_ShouldCallMapMethod()
        {
            // ARRANGE
            int id = 10;
            MockDTO mockDTO = new MockDTO() { Id = id };
            MockEntity updatedMocKEntity = new MockEntity() { Id = id };
            _repoMock.Setup(x => x.UpdateEntity(It.IsAny<MockEntity>())).Returns(updatedMocKEntity);

            // ACT
            _service.UpdateEntity(id, mockDTO);

            // ASSERT
            _mapperMock.Verify(x => x.Map<MockEntity>(mockDTO), Times.Once);
        }

        [Test]
        public void UpdateEntity_WhenEntityExists_ShouldReturnSuccess()
        {
            // ARRANGE
            int id = 10;
            MockDTO mockDTO = new MockDTO() { Id = id };
            MockEntity updatedMocKEntity = new MockEntity() { Id = id };
            _repoMock.Setup(x => x.UpdateEntity(It.IsAny<MockEntity>())).Returns(updatedMocKEntity);

            // ACT
            var response = _service.UpdateEntity(id, mockDTO);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public void UpdateEntity_WhenEntityDoesNotExist_ShouldReturnNotFound()
        {
            // ARRANGE
            int id = 10;
            MockDTO mockDTO = new MockDTO() { Id = 10 };
            _repoMock.Setup(x => x.UpdateEntity(It.IsAny<MockEntity>())).Returns(() => null);

            // ACT
            var response = _service.UpdateEntity(id, mockDTO);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.NotFound);
        }
    }
}
