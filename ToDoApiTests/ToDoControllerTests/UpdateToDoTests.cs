using Microsoft.AspNetCore.Http;


namespace ToDoApiTests.ToDoControllerTests
{
    internal sealed class UpdateToDoTests
    {
        [Test]
        public async Task UpdateToDoReturnsOk()
        {
            ToDoDto newToDoDto = new ToDoDto()
            {
                Id = 1,
                Name = "Помыть полы",
                Deadline = "29-11-2023 12:00",
                CreatedDate = "29-11-2023 12:00",
                Completed = true
            };

            ToDoDto oldToDoDto = new ToDoDto()
            {
                Id = 1,
                Name = "Помыть полы",
                Deadline = "29-11-2023 12:00",
                CreatedDate = "29-11-2023 12:00"
            };

            ToDo oldToDo = new ToDo
            {
                Id = 1,
                Name = "Помыть полы",
                Deadline = new DateTime(2023, 11, 29, 12, 00, 00),
                CreatedDate = new DateTime(2023, 11, 29, 12, 00, 00)
            };

            ToDo newToDo = new ToDo
            {
                Id = 1,
                Name = "Помыть полы",
                Deadline = new DateTime(2023, 11, 29, 12, 00, 00),
                CreatedDate = new DateTime(2023, 11, 29, 12, 00, 00),
                Completed = true
            };

            //moq repository
            var mockRepo = new Mock<IToDoRepository>();
            mockRepo.Setup(repo => repo.GetAsync(x => x.Id == 1))
                    .ReturnsAsync(newToDo);
            mockRepo.Setup(repo => repo.UpdateAsync(oldToDo))
                .ReturnsAsync(newToDo);


            //init automapper
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingConfig>();
            });
            IMapper mapper = new Mapper(config);

            var controller = new ToDoController(mockRepo.Object, mapper);
            // Act
            var result = await controller.UpdateToDoAsync(1,newToDoDto);
            var okResult = result as OkObjectResult;
            // Assert
            Assert.True(okResult.StatusCode is StatusCodes.Status200OK);
        }
    }
}
