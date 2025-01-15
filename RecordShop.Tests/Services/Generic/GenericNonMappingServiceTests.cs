using NUnit.Framework;
using Moq;
using RecordShop.Model;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Generic;
using FluentAssertions;
using RecordShop.Services.Response;
using RecordShop.Tests.Utility;

namespace RecordShop.Tests.Services.Generic
{
    public class GenericNonMappingServiceTests
    {
        private Mock<IGenericRepository<MockEntity>> _repoMock;
        private GenericNonMappingService<MockEntity> _service;

        [SetUp]
        public void Init()
        {
            _repoMock = new Mock<IGenericRepository<MockEntity>>();
            _service = new GenericNonMappingService<MockEntity>(_repoMock.Object);
        }

        [Test]
        public void DeleteEntityById_ShouldCallAppropriateRepoMethods([Range(0,10,2)] int id)
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
        public void GetEntities_WhenEntitiesExist_ShouldReturnEntities()
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
            response.Value.Should().BeEquivalentTo(mockEntities);
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
        public void GetEntityById_WhenEntityExists_ShouldReturnEntity()
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new MockEntity() { Id = id };
            _repoMock.Setup(x => x.GetEntityById(id)).Returns(mockEntity);

            // ACT
            var response = _service.GetEntityById(id);

            // ASSERT
            response.Value.Should().Be(mockEntity);
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
            MockEntity mockEntity = new MockEntity() { Id = 10 };
            _repoMock.Setup(x => x.InsertEntity(mockEntity)).Returns(() => 11);

            // ACT
            _service.InsertEntity(mockEntity);

            // ASSERT
            _repoMock.Verify(x => x.InsertEntity(mockEntity), Times.Once);
            _repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Test]
        public void InsertEntity_ShouldReturnNewEntityId([Range(0, 10, 2)] int newId)
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new MockEntity() { Id = id };
            var expectedEntity = new MockEntity() { Id = newId };
            _repoMock.Setup(x => x.InsertEntity(mockEntity)).Returns(() => newId);

            // ACT
            var response = _service.InsertEntity(mockEntity);

            // ASSERT
            response.Value.Should().Be(newId);
        }

        [Test]
        public void InsertEntity_ShouldReturnSuccess()
        {
            // ARRANGE
            var mockEntity = new MockEntity();
            _repoMock.Setup(x => x.InsertEntity(mockEntity)).Returns(() => 1);

            // ACT
            var response = _service.InsertEntity(mockEntity);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public void UpdateEntity_ShouldCallAppropriateRepoMethods()
        {
            // ARRANGE
            int id = 10;
            MockEntity mockEntity = new MockEntity() { Id = id };
            _repoMock.Setup(x => x.UpdateEntity(mockEntity)).Returns(mockEntity);

            // ACT
            _service.UpdateEntity(id, mockEntity);

            // ASSERT
            _repoMock.Verify(x => x.UpdateEntity(mockEntity), Times.Once);
            _repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Test]
        public void UpdateEntity_WhenEntityExists_ShouldReturnSuccess()
        {
            // ARRANGE
            int id = 10;
            var mockEntity = new MockEntity() { Id = id };
            _repoMock.Setup(x => x.UpdateEntity(mockEntity)).Returns(mockEntity);

            // ACT
            var response = _service.UpdateEntity(id, mockEntity);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.Success);
        }

        [Test]
        public void UpdateEntity_WhenEntityDoesNotExist_ShouldReturnNotFound()
        {
            // ARRANGE
            int id = 10;
            var mockEntity = new MockEntity() { Id = id };
            _repoMock.Setup(x => x.UpdateEntity(mockEntity)).Returns(() => null);

            // ACT
            var response = _service.UpdateEntity(id, mockEntity);

            // ASSERT
            response.ResponseType.Should().Be(ServiceResponseType.NotFound);
        }   
    }
}
