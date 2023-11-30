
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ToDoApiTests.ToDoControllerTests
{
    internal sealed class CreateToDoTests
    {
        [Test]
        public async Task CreateToDoReturnsExpectedResult()
        {
            ToDoDto expected = new ToDoDto()
            {
                Id = 0,
                Name = "Помыть полы",
                Deadline = "29-11-2023 12:00",
                CreatedDate = "29-11-2023 12:00"
            };

            ToDo toDo = new ToDo
            {
                Id = 0,
                Name = "Помыть полы",
                Deadline = new DateTime(2023, 11, 29, 12, 00, 00),
                CreatedDate = new DateTime(2023, 11, 29, 12, 00, 00)
            };

            //moq repository
            var mockRepo = new Mock<IToDoRepository>();
            mockRepo.Setup(repo => repo.GetAsync(x => x.Id == 1))
                    .ReturnsAsync(toDo);
            mockRepo.Setup(repo => repo.CreateAsync(toDo));


            //init automapper
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingConfig>();
            });
            IMapper mapper = new Mapper(config);

            var controller = new ToDoController(mockRepo.Object, mapper);
            // Act
            var result = await controller.CreateToDoAsync(expected);
            var actual = (result.Result as ObjectResult).Value;
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

