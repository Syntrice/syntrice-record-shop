using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordShop.Controllers.API.Generic;
using RecordShop.Services.Generic;
using RecordShop.Services.Response;
using RecordShop.Tests.Utility;

namespace RecordShop.Tests.Controllers.API.Generic
{
    public class GenericNonMappingControllerTests
    {
        private Mock<IGenericNonMappingService<MockEntity>> _serviceMock;
        private GenericNonMappingController<MockEntity> _controller;

        [SetUp]
        public void Init()
        {
            _serviceMock = new Mock<IGenericNonMappingService<MockEntity>>();
            _controller = new GenericNonMappingController<MockEntity>(_serviceMock.Object);
        }

        [Test]
        public void Get_ShouldCallAppropriateServiceMethod()
        {
            // ARRANGE
            var serviceResponse = new ServiceObjectResponse<List<MockEntity>>(ServiceResponseType.NotFound, "message", null);
            _serviceMock.Setup(x => x.GetEntities()).Returns(() => serviceResponse);

            // ACT
            _controller.Get();

            // ASSERT
            _serviceMock.Verify(x => x.GetEntities(), Times.Once);
        }

        [Test]
        public void Get_WhenNotFoundServiceResponse_ReturnsNotFoundWithMessage()
        {
            // ARRANGE
            var serviceResponse = new ServiceObjectResponse<List<MockEntity>>(ServiceResponseType.NotFound, "message", null);
            _serviceMock.Setup(x => x.GetEntities()).Returns(() => serviceResponse);

            // ACT
            var result = _controller.Get();

            // ASSERT
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
            okResult.Value.Should().Be(serviceResponse.Message);
        }

        [Test]
        public void Get_WhenSuccessServiceResponse_ReturnsOkObjectResult()
        {
            // ARRANGE
            var mockEntities = new List<MockEntity>() { new MockEntity() };
            var serviceResponse = new ServiceObjectResponse<List<MockEntity>>(ServiceResponseType.Success, null, mockEntities);
            _serviceMock.Setup(x => x.GetEntities()).Returns(() => serviceResponse);

            // ACT
            var result = _controller.Get();

            // ASSERT
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void GetById_ShouldCallAppropriateServiceMethod([Range(0,1)] int id)
        {
            // ARRANGE
            var serviceResponse = new ServiceObjectResponse<MockEntity>(ServiceResponseType.NotFound, "message", null);
            _serviceMock.Setup(x => x.GetEntityById(id)).Returns(serviceResponse);

            // ACT
            _controller.GetById(id);

            // ASSERT
            _serviceMock.Verify(x => x.GetEntityById(id), Times.Once);
        }

        [Test]
        public void GetById_WhenNotFoundServiceResponse_ReturnsNotFoundWithMessage()
        {
            // ARRANGE
            int id = 1;
            var serviceResponse = new ServiceObjectResponse<MockEntity>(ServiceResponseType.NotFound, "message", null);
            _serviceMock.Setup(x => x.GetEntityById(id)).Returns(serviceResponse);

            // ACT
            var result = _controller.GetById(id);

            // ASSERT
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
            okResult.Value.Should().Be(serviceResponse.Message);
        }

        [Test]
        public void GetById_WhenSuccessServiceResponse_ReturnsOkObjectResult()
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new MockEntity() { Id = id };
            var serviceResponse = new ServiceObjectResponse<MockEntity>(ServiceResponseType.Success, null, mockEntity);
            _serviceMock.Setup(x => x.GetEntityById(id)).Returns(serviceResponse);

            // ACT
            var result = _controller.GetById(id);

            // ASSERT
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void Post_ShouldCallAppropriateServiceMethod()
        {
            // ARRANGE
            var mockEntity = new MockEntity();
            var serviceResponse = new ServiceObjectResponse<MockEntity>(ServiceResponseType.Success, null, mockEntity);
            _serviceMock.Setup(x => x.InsertEntity(mockEntity)).Returns(serviceResponse);

            // ACT
            _controller.Post(mockEntity);

            // ASSERT
            _serviceMock.Verify(x => x.InsertEntity(mockEntity), Times.Once);
        }

        [Test]
        public void Post_WhenSuccessServiceResponse_ReturnsCreatedResult()
        {
            // ARRANGE
            var mockEntity = new MockEntity();
            var serviceResponse = new ServiceObjectResponse<MockEntity>(ServiceResponseType.Success, null, mockEntity);
            _serviceMock.Setup(x => x.InsertEntity(mockEntity)).Returns(serviceResponse);

            // ACT
            var result = _controller.Post(mockEntity);

            // ASSERT
            result.Should().BeOfType<CreatedResult>();
        }

        [Test]
        public void Delete_ShouldCallAppropriateServiceMethod([Range(0, 1)] int id)
        {
            // ARRANGE
            var serviceResponse = new ServiceResponse(ServiceResponseType.NotFound, "message");
            _serviceMock.Setup(x => x.DeleteEntityById(id)).Returns(serviceResponse);

            // ACT
            _controller.Delete(id);

            // ASSERT
            _serviceMock.Verify(x => x.DeleteEntityById(id), Times.Once);
        }

        [Test]
        public void Delete_WhenNotFoundServiceResponse_ReturnsNotFoundWithMessage()
        {
            // ARRANGE
            int id = 1;
            var serviceResponse = new ServiceResponse(ServiceResponseType.NotFound, "message");
            _serviceMock.Setup(x => x.DeleteEntityById(id)).Returns(serviceResponse);

            // ACT
            var result = _controller.Delete(id);

            // ASSERT
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
            okResult.Value.Should().Be(serviceResponse.Message);
        }

        [Test]
        public void Delete_WhenSuccessServiceResponse_ReturnsNoContentResult()
        {
            // ARRANGE
            int id = 1;
            var serviceResponse = new ServiceResponse(ServiceResponseType.Success, null);
            _serviceMock.Setup(x => x.DeleteEntityById(id)).Returns(serviceResponse);

            // ACT
            var result = _controller.Delete(id);

            // ASSERT
            result.Should().BeOfType<NoContentResult>();
        }


        [Test]
        public void Put_ShouldCallAppropriateServiceMethod([Range(0, 1)] int id)
        {
            // ARRANGE
            var mockEntity = new MockEntity() { Id = id };
            var serviceResponse = new ServiceResponse(ServiceResponseType.NotFound, "message");
            _serviceMock.Setup(x => x.UpdateEntity(mockEntity)).Returns(serviceResponse);

            // ACT
            _controller.Put(id, mockEntity);

            // ASSERT
            _serviceMock.Verify(x => x.UpdateEntity(mockEntity), Times.Once);
        }

        [Test]
        public void Put_WhenNotFoundServiceResponse_ReturnsNotFoundWithMessage()
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new MockEntity() { Id = id };
            var serviceResponse = new ServiceResponse(ServiceResponseType.NotFound, "message");
            _serviceMock.Setup(x => x.UpdateEntity(mockEntity)).Returns(serviceResponse);

            // ACT
            var result = _controller.Put(id, mockEntity);

            // ASSERT
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
            okResult.Value.Should().Be(serviceResponse.Message);
        }

        [Test]
        public void Put_WhenSuccessServiceResponse_ReturnsNoContentResult()
        {
            // ARRANGE
            int id = 1;
            var mockEntity = new MockEntity() { Id = id };
            var serviceResponse = new ServiceResponse(ServiceResponseType.Success, null);
            _serviceMock.Setup(x => x.UpdateEntity(mockEntity)).Returns(serviceResponse);

            // ACT
            var result = _controller.Put(id, mockEntity);

            // ASSERT
            result.Should().BeOfType<NoContentResult>();
        }
    }
}