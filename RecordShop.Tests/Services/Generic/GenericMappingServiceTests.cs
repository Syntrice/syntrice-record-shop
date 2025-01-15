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
        private GenericMappingService<MockEntity, MockDTO> _service;

        [SetUp]
        public void Init()
        {
            _repoMock = new Mock<IGenericRepository<MockEntity>>();
            _mapperMock = new Mock<IMapper>();

            // Mock mapping
            _mapperMock.Setup(m => m.Map<MockEntity, MockDTO>(It.IsAny<MockEntity>())).Returns((MockEntity src) => new MockDTO() { Id = src.Id});
            _mapperMock.Setup(m => m.Map<MockDTO, MockEntity>(It.IsAny<MockDTO>())).Returns((MockDTO src) => new MockEntity() { Id = src.Id});

            _service = new GenericMappingService<MockEntity, MockDTO>(_repoMock.Object, _mapperMock.Object);
        }

        [Test]
        public void DeleteEntityById_ShouldCallAppropriateRepoMethods([Range(0, 10, 2)] int id)
        {
            Assert.Fail();
        }

        [Test]
        public void DeleteEntityById_WhenEntityFound_ShouldReturnSuccess()
        {
            Assert.Fail();
        }

        [Test]
        public void DeleteEntityById_WhenEntityNotFound_ShouldReturnNotFound()
        {
            Assert.Fail();
        }

        [Test]
        public void GetEntities_ShouldCallAppropriateRepoMethods()
        {
            Assert.Fail();
        }

        [Test]
        public void GetEntities_ShouldCallMapMethod()
        {
            Assert.Fail();
        }


        [Test]
        public void GetEntities_WhenEntitiesExist_ShouldReturnSuccess()
        {
            Assert.Fail();
        }

        [Test]
        public void GetEntities_WhenEntitiesExist_ShouldReturnMappedEntities()
        {
            Assert.Fail();
        }

        [Test]
        public void GetEntities_WhenEntitiesDoNotExist_ShouldReturnNotFound()
        {
            Assert.Fail();
        }


        [Test]
        public void GetEntityById_ShouldCallAppropriateRepoMethods([Range(0, 10, 2)] int id)
        {
            Assert.Fail();
        }

        [Test]
        public void GetEntityById_ShouldCallMapMethod()
        {
            Assert.Fail();
        }

        [Test]
        public void GetEntityById_WhenEntityExists_ShouldReturnSuccess()
        {
            Assert.Fail();
        }

        [Test]
        public void GetEntityById_WhenEntityExists_ShouldReturnMappedEntity()
        {
            Assert.Fail();
        }

        [Test]
        public void GetEntityById_WhenEntityDoesNotExist_ShouldReturnNotFound()
        {
            Assert.Fail();
        }

        [Test]
        public void InsertEntity_ShouldCallAppropriateRepoMethods()
        {
            Assert.Fail();
        }

        [Test]
        public void InsertEntity_ShouldCallMapMethod()
        {
            Assert.Fail();
        }

        [Test]
        public void InsertEntity_ShouldReturnMappedInsertedEntity_WithUpdatedId([Range(0, 10, 2)] int newId)
        {
            Assert.Fail();
        }

        [Test]
        public void InsertEntity_ShouldReturnSuccess()
        {
            Assert.Fail();
        }

        [Test]
        public void UpdateEntity_ShouldCallAppropriateRepoMethods()
        {
            Assert.Fail();
        }

        [Test]
        public void UpdateEntity_ShouldCallMapMethod()
        {
            Assert.Fail();
        }

        [Test]
        public void UpdateEntity_WhenEntityExists_ShouldReturnSuccess()
        {
            Assert.Fail();
        }

        [Test]
        public void UpdateEntity_WhenEntityDoesNotExist_ShouldReturnNotFound()
        {
            Assert.Fail();
        }
    }
}
