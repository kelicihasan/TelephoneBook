using Contact.API.Controllers;
using Contact.Application.Dtos.Person.Request;
using Contact.Application.Dtos.Person.Response;
using Contact.Application.Services;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Contact.Test
{
    public class PersonApiControllerTest
    {
        private readonly Mock<IPersonService> _mock;
        private readonly PersonsController _controller;

        IEnumerable<GetPersonDto> list;
        public PersonApiControllerTest()
        {
            _mock = new Mock<IPersonService>();
            _controller = new PersonsController(_mock.Object, null);

            list = new List<GetPersonDto>()
            {
                new GetPersonDto { Id = Guid.Parse("c205e437-3102-4293-9d17-3d62b94b3dea"),Name="hasan",SurName="hasan"},
                new GetPersonDto { Id = Guid.Parse("17644ecb-fb19-47f0-a0cf-fa50443875d1"),Name="yusuf",SurName="kelici"},
                new GetPersonDto { Id = Guid.Parse("6662d3a5-feaa-4101-a852-0c235df9a7b7"),Name="huseyin",SurName="kelici"}
            };
        }

        [Fact]
        public async void GetPerson_ActionExecutes_ReturnOkResultWithPerson()
        {
            _mock.Setup(x => x.GetAllPerson()).ReturnsAsync(list);
            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnValue = Assert.IsAssignableFrom<IEnumerable<GetPersonDto>>(okResult.Value);

            Assert.Equal(3, list.Count());
        }
        [Theory]
        [InlineData("d4d7c55c-18f1-4aff-a68f-544d0f20ae80")]
        public async void DeletePerson_IdInValid_ReturnBadRequest(Guid personId)
        {
            _mock.Setup(x => x.DeletePerson(personId)).ReturnsAsync(false);

            var result = await _controller.DeletePerson(personId);

            Assert.Equal(false, false);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void CreatePerson_ActionExecutes_ReturnOk()
        {
            var person = new PersonCreateRequestDto
            {
                Name = "Muhsin",
                SurName = "KANADIKIRIK"
            };

            _mock.Setup(x => x.CreatePerson(person)).ReturnsAsync(true);

            var result = await _controller.Create(person);

            _mock.Verify(x => x.CreatePerson(person), Times.Once);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnBool = Assert.IsType<bool>(okResult.Value);

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(true, returnBool);
        }
    }
}
