using Contact.API.Controllers;
using Contact.Application.Dtos.Person.Request;
using Contact.Application.Dtos.Person.Response;
using Contact.Application.Services;
using Contact.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Contact.Test
{
    public class PersonApiControllerTest
    {
        private readonly Mock<IPersonService> _mock;
        private readonly PersonController _controller;

        IEnumerable<GetPersonDto> gertPersonDtolist;
        IEnumerable<Person> Personlist;
        public PersonApiControllerTest()
        {
            _mock = new Mock<IPersonService>();
            _controller = new PersonController(_mock.Object, null);

            gertPersonDtolist = new List<GetPersonDto>()
            {
                new GetPersonDto { Id = Guid.Parse("c205e437-3102-4293-9d17-3d62b94b3dea"),Name="hasan",SurName="hasan"},
                new GetPersonDto { Id = Guid.Parse("17644ecb-fb19-47f0-a0cf-fa50443875d1"),Name="yusuf",SurName="kelici"},
                new GetPersonDto { Id = Guid.Parse("6662d3a5-feaa-4101-a852-0c235df9a7b7"),Name="huseyin",SurName="kelici"}
            };

            Personlist = gertPersonDtolist.Select(x => new Person
            {
                Id = x.Id,
                Name = x.Name,
                SurName = x.SurName
            });
        }

        [Fact]
        public async void GetPerson_ActionExecutes_ReturnOkResultWithPerson()
        {
            _mock.Setup(x => x.GetAllPerson()).ReturnsAsync(gertPersonDtolist);
            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnValue = Assert.IsAssignableFrom<IEnumerable<GetPersonDto>>(okResult.Value);

            Assert.Equal(3, gertPersonDtolist.Count());
        }
        [Theory]
        [InlineData("d4d7c55c-18f1-4aff-a68f-544d0f20ae80")]
        public async void DeletePerson_IdInValid_ReturnBadRequest(Guid personId)
        {
            _mock.Setup(x => x.DeletePerson(personId)).ReturnsAsync(null);

            var result = await _controller.DeletePerson(personId);
            var badrequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(false, badrequestResult.Value);

            Assert.IsType<BadRequestResult>(result);
        }

        [Theory]
        [InlineData("d4d7c55c-18f1-4aff-a68f-544d0f20ae80")]
        public async void GetPersonContactsByPersonId_IdInValid_ReturnBadRequest(Guid personId)
        {
            _mock.Setup(x => x.GetPersonContactsByPersonId(personId)).ReturnsAsync(Personlist);

            var result = await _controller.DeletePerson(personId);

            var badrequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnBool = Assert.IsType<bool>(badrequestResult.Value);
            Assert.Equal(true, returnBool);
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
