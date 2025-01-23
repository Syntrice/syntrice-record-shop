using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordShop.Controllers.API.Generic;
using RecordShop.Model;
using RecordShop.Services.Generic;
using RecordShop.Services.Response;

namespace RecordShop.Tests.Controllers.API.Generic
{
    public abstract class GenericCRUDControllerTests<TEntity, TGetDTO, TInsertDTO, TUpdateDTO>
        where TEntity : class, IEntity, new()
        where TGetDTO : class, IGetDTO, new()
        where TInsertDTO : class, IInsertDTO, new()
        where TUpdateDTO : class, IUpdateDTO, new()
    {
        private Mock<IGenericCRUDService<TEntity, TGetDTO, TInsertDTO, TUpdateDTO>> _serviceMock = null!;
        private GenericCRUDController<TEntity, TGetDTO, TInsertDTO, TUpdateDTO> _controller = null!;

        [SetUp]
        protected virtual void Init()
        {
            _serviceMock = new Mock<IGenericCRUDService<TEntity, TGetDTO, TInsertDTO, TUpdateDTO>>();
            _controller = new GenericCRUDController<TEntity, TGetDTO, TInsertDTO, TUpdateDTO>(_serviceMock.Object);
        }

        [Test]
        public virtual void Get_ShouldCallAppropriateServiceMethod()
        {
            // ARRANGE
            var serviceResponse = new ServiceObjectResponse<List<TGetDTO>>(ServiceResponseType.NotFound, "message", null);
            _serviceMock.Setup(x => x.GetEntities()).Returns(() => serviceResponse);

            // ACT
            _controller.Get();

            // ASSERT
            _serviceMock.Verify(x => x.GetEntities(), Times.Once);
        }

        [Test]
        public virtual void Get_WhenNotFoundServiceResponse_ReturnsNotFoundWithMessage()
        {
            // ARRANGE
            var serviceResponse = new ServiceObjectResponse<List<TGetDTO>>(ServiceResponseType.NotFound, "message", null);
            _serviceMock.Setup(x => x.GetEntities()).Returns(() => serviceResponse);

            // ACT
            var result = _controller.Get();

            // ASSERT
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
            okResult.Value.Should().Be(serviceResponse.Message);
        }

        [Test]
        public virtual void Get_WhenSuccessServiceResponse_ReturnsOkObjectResult()
        {
            // ARRANGE
            var mockGetDTOs = new List<TGetDTO>() { new TGetDTO() };
            var serviceResponse = new ServiceObjectResponse<List<TGetDTO>>(ServiceResponseType.Success, null, mockGetDTOs);
            _serviceMock.Setup(x => x.GetEntities()).Returns(() => serviceResponse);

            // ACT
            var result = _controller.Get();

            // ASSERT
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public virtual void GetById_ShouldCallAppropriateServiceMethod([Range(0,1)] int id)
        {
            // ARRANGE
            var serviceResponse = new ServiceObjectResponse<TGetDTO>(ServiceResponseType.NotFound, "message", null);
            _serviceMock.Setup(x => x.GetEntityById(id)).Returns(serviceResponse);

            // ACT
            _controller.GetById(id);

            // ASSERT
            _serviceMock.Verify(x => x.GetEntityById(id), Times.Once);
        }

        [Test]
        public virtual void GetById_WhenNotFoundServiceResponse_ReturnsNotFoundWithMessage()
        {
            // ARRANGE
            int id = 1;
            var serviceResponse = new ServiceObjectResponse<TGetDTO>(ServiceResponseType.NotFound, "message", null);
            _serviceMock.Setup(x => x.GetEntityById(id)).Returns(serviceResponse);

            // ACT
            var result = _controller.GetById(id);

            // ASSERT
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
            okResult.Value.Should().Be(serviceResponse.Message);
        }

        [Test]
        public virtual void GetById_WhenSuccessServiceResponse_ReturnsOkObjectResult()
        {
            // ARRANGE
            int id = 1;
            var mockGetDTO = new TGetDTO();
            var serviceResponse = new ServiceObjectResponse<TGetDTO>(ServiceResponseType.Success, null, mockGetDTO);
            _serviceMock.Setup(x => x.GetEntityById(id)).Returns(serviceResponse);

            // ACT
            var result = _controller.GetById(id);

            // ASSERT
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public virtual void Post_ShouldCallAppropriateServiceMethod()
        {
            // ARRANGE
            var mockInsertDTO = new TInsertDTO();
            var serviceResponse = new ServiceObjectResponse<int>(ServiceResponseType.Success, null, 0);
            _serviceMock.Setup(x => x.InsertEntity(mockInsertDTO)).Returns(serviceResponse);

            // ACT
            _controller.Post(mockInsertDTO);

            // ASSERT
            _serviceMock.Verify(x => x.InsertEntity(mockInsertDTO), Times.Once);
        }

        [Test]
        public virtual void Post_WhenSuccessServiceResponse_ReturnsCreatedResult()
        {
            // ARRANGE
            var mockInsertDTO = new TInsertDTO();
            var serviceResponse = new ServiceObjectResponse<int>(ServiceResponseType.Success, null, 0);
            _serviceMock.Setup(x => x.InsertEntity(mockInsertDTO)).Returns(serviceResponse);

            // ACT
            var result = _controller.Post(mockInsertDTO);

            // ASSERT
            result.Should().BeOfType<CreatedResult>();
        }

        [Test]
        public virtual void Delete_ShouldCallAppropriateServiceMethod([Range(0, 1)] int id)
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
        public virtual void Delete_WhenNotFoundServiceResponse_ReturnsNotFoundWithMessage()
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
        public virtual void Delete_WhenSuccessServiceResponse_ReturnsNoContentResult()
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
        public virtual void Put_ShouldCallAppropriateServiceMethod([Range(0, 1)] int id)
        {
            // ARRANGE
            var mockInsertDTO = new TUpdateDTO();
            var serviceResponse = new ServiceResponse(ServiceResponseType.NotFound, "message");
            _serviceMock.Setup(x => x.UpdateEntity(id, mockInsertDTO)).Returns(serviceResponse);

            // ACT
            _controller.Put(id, mockInsertDTO);

            // ASSERT
            _serviceMock.Verify(x => x.UpdateEntity(id, mockInsertDTO), Times.Once);
        }

        [Test]
        public virtual void Put_WhenNotFoundServiceResponse_ReturnsNotFoundWithMessage()
        {
            // ARRANGE
            int id = 1;
            var mockInsertDTO = new TUpdateDTO();
            var serviceResponse = new ServiceResponse(ServiceResponseType.NotFound, "message");
            _serviceMock.Setup(x => x.UpdateEntity(id, mockInsertDTO)).Returns(serviceResponse);

            // ACT
            var result = _controller.Put(id, mockInsertDTO);

            // ASSERT
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
            okResult.Value.Should().Be(serviceResponse.Message);
        }

        [Test]
        public virtual void Put_WhenSuccessServiceResponse_ReturnsNoContentResult()
        {
            // ARRANGE
            int id = 1;
            var mockInsertDTO = new TUpdateDTO();
            var serviceResponse = new ServiceResponse(ServiceResponseType.Success, null);
            _serviceMock.Setup(x => x.UpdateEntity(id, mockInsertDTO)).Returns(serviceResponse);

            // ACT
            var result = _controller.Put(id, mockInsertDTO);

            // ASSERT
            result.Should().BeOfType<NoContentResult>();
        }
    }
}