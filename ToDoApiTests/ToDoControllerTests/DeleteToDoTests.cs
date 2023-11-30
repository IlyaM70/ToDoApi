using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApiTests.ToDoControllerTests
{
    internal sealed class DeleteToDoTests
    {
        [Test]
        public async Task DeleteToDoReturnsOk()
        {
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
            mockRepo.Setup(repo => repo.RemoveAsync(toDo));


            //init automapper
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingConfig>();
            });
            IMapper mapper = new Mapper(config);

            var controller = new ToDoController(mockRepo.Object, mapper);
            // Act
            var result = await controller.DeleteToDoAsync(1);
            var okResult = result as OkResult;
            // Assert
            Assert.True(okResult.StatusCode is StatusCodes.Status200OK);
        }
    }
}
