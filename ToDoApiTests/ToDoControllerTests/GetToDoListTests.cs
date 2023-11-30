namespace ToDoApiTests.ToDoControllerTests
{
    internal sealed class GetToDoListTests
    {
        [Test]
        public async Task GetToDoReturnsExpectedResult()
        {
            // Arrange

            //Expected result
            List<ToDoDto> toDoDtoList = new List<ToDoDto>() {
                new ToDoDto
                {
                    Id = 1,
                    Name = "Помыть полы",
                    Deadline = "29-11-2023 12:00",
                    CreatedDate = "29-11-2023 12:00"
                },
                new ToDoDto
                {
                    Id = 2,
                    Name = "Сходить в магазин",
                    Deadline = "29-11-2023 12:00",
                    Description = "Купить яблоки и бананы",
                    CreatedDate = "29-11-2023 12:00"
                },
                new ToDoDto
                {
                    Id = 3,
                    Name = "Вынести мусор",
                    Deadline = "29-11-2023 12:00",
                    Completed = true,
                    CreatedDate = "29-11-2023 12:00"
                }
            };

            List<ToDo> toDoList = new List<ToDo>() {
                new ToDo
                {
                    Id = 1,
                    Name = "Помыть полы",
                    Deadline = new DateTime(2023,11,29,12,00,00),
                    CreatedDate = new DateTime(2023,11,29,12,00,00)
                },
                new ToDo
                {
                    Id = 2,
                    Name = "Сходить в магазин",
                    Deadline = new DateTime(2023,11,29,12,00,00),
                    CreatedDate = new DateTime(2023,11,29,12,00,00),
                    Description = "Купить яблоки и бананы"
                },
                new ToDo
                {
                    Id = 3,
                    Name = "Вынести мусор",
                    Deadline = new DateTime(2023,11,29,12,00,00),
                    CreatedDate = new DateTime(2023,11,29,12,00,00),
                    Completed = true
                }
            };

            //moq repository
            var mockRepo = new Mock<IToDoRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync(null))
                .ReturnsAsync(toDoList);
            //init automapper
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingConfig>();
            });
            IMapper mapper = new Mapper(config);

            var controller = new ToDoController(mockRepo.Object, mapper);
            // Act
            var result = await controller.GetToDosAsync();
            var actual = (result.Result as ObjectResult).Value as List<ToDoDto>;

            // Assert
            CollectionAssert.AreEqual(toDoDtoList, actual);
        }

    }
}
