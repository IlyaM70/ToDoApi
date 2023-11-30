using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Data.Repositories.RepositoryInterfaces;
using ToDoApi.Models.DTOs;
using ToDoApi.Models.Entities;

namespace ToDoApi.Controllers
{
    [Route("ToDoApi")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _db;
        private readonly IMapper _mapper;
        public ToDoController(IToDoRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        ///////////////////////////////////GetToDoList
        [HttpGet("GetToDoList")]
        public async Task<ActionResult<IEnumerable<ToDoDto>>> GetToDosAsync()
        {
            IEnumerable<ToDo> ToDoList = await _db.GetAllAsync();
            IEnumerable<ToDoDto> toDoDtoList = _mapper.Map<IEnumerable<ToDoDto>>(ToDoList);
            return Ok(toDoDtoList);
        }

        ///////////////////////////////////GetToDo
        [HttpGet("GetToDo/{id:int}", Name = "GetToDo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ToDoDto>> GetToDoAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            ToDo? ToDo = await _db.GetAsync(x => x.Id == id);
            if (ToDo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ToDoDto>(ToDo));
        }

        ///////////////////////////////////CreateToDo
        [HttpPost("CreateToDo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ToDoDto>> CreateToDoAsync([FromBody] ToDoDto toDoDto)
        {

            if (toDoDto == null)
            {
                return BadRequest();
            }
            if (toDoDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


            ToDo toDo = _mapper.Map<ToDo>(toDoDto);

            if (toDoDto.CreatedDate == null)
            {
                toDo.CreatedDate = DateTime.Now;
            }

            if (toDo.Deadline == default(DateTime))
            {
                return BadRequest();
            }

            await _db.CreateAsync(toDo);
            await _db.SaveAsync();

            toDoDto.Id = toDo.Id;

            return CreatedAtRoute("GetToDo", new { id = toDo.Id },toDoDto);
        }

        ///////////////////////////////////DeleteToDo
        [HttpDelete("DeleteToDo/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteToDoAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            ToDo? toDo = await _db.GetAsync(x => x.Id == id);

            if (toDo == null)
            {
                return NotFound();
            }
            await _db.RemoveAsync(toDo);
            await _db.SaveAsync();
            return Ok();
        }

        ///////////////////////////////////UpdateToDo
        [HttpPut("UpdateToDo/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateToDoAsync(int id, [FromBody] ToDoDto toDoDto)
        {
            if (toDoDto == null || id != toDoDto.Id)
            {
                return BadRequest();
            }

            ToDo toDo = _mapper.Map<ToDo>(toDoDto);

            if (toDo.Deadline == default(DateTime))
            {
                return BadRequest();
            }
            //if null don't update
            if (toDoDto.CreatedDate == null)
            {
                toDo.CreatedDate = null;
            }

            await _db.UpdateAsync(toDo);
            await _db.SaveAsync();

            return Ok(_db.GetAsync(x=>x.Id==toDo.Id));
        }
    }
}
