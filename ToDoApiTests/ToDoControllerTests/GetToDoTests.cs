using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ToDoApiTests.ToDoControllerTests
{
    internal sealed class GetToDoTests
    {
        [Test]
        public async Task GetToDoReturnsExpectedResult()
        {
            ToDoDto expected = new ToDoDto()
            {
                Id = 1,
                Name = "Помыть полы",
                Deadline = "29-11-2023 12:00",
                CreatedDate = "29-11-2023 12:00"
            };

            ToDo toDo = new ToDo
            {
                Id = 1,
                Name = "Помыть полы",
                Deadline = new DateTime(2023, 11, 29, 12, 00, 00),
                CreatedDate = new DateTime(2023, 11, 29, 12, 00, 00)
            };

            //moq repository
            var mockRepo = new Mock<IToDoRepository>();
            mockRepo.Setup(repo => repo.GetAsync(x => x.Id == 1))
                .ReturnsAsync(toDo);

            //init automapper
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingConfig>();
            });
            IMapper mapper = new Mapper(config);

            var controller = new ToDoController(mockRepo.Object, mapper);
            // Act
            var result = await controller.GetToDoAsync(1);
            var actual = (result.Result as ObjectResult).Value as ToDoDto;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
