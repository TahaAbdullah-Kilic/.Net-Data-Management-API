using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Models.Domain;
using TaskManagement.API.Models.Dto;
using TaskManagement.API.Repositories;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTasksController : ControllerBase
    {
        readonly IWorkTaskRepository workTaskRepository;
        readonly IMapper Mapper;

        public WorkTasksController(IWorkTaskRepository workTaskRepository, IMapper mapper)
        {
            this.workTaskRepository = workTaskRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await workTaskRepository.GetAllAsync();

            if (tasks == null || !tasks.Any())
            {
                return NotFound();
            }

            var tasksDto = Mapper.Map<List<WorkTaskDto>>(tasks);

            return Ok(tasksDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var task = await workTaskRepository.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            var taskDto = Mapper.Map<WorkTaskDto>(task);

            return Ok(taskDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWorkTaskRequestDto addWorkTaskRequestDto)
        {
            var task = Mapper.Map<WorkTask>(addWorkTaskRequestDto);

            task = await workTaskRepository.CreateAsync(task);

            var taskDto = Mapper.Map<WorkTaskDto>(task);

            return CreatedAtAction(nameof(GetById), new { id = taskDto.Id }, taskDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWorkTaskRequestDto updateWorkTaskRequestDto)
        {
            var task = Mapper.Map<WorkTask>(updateWorkTaskRequestDto);

            task = await workTaskRepository.UpdateAsync(id, task);

            if (task == null)
            {
                return NotFound();
            }

            var taskDto = Mapper.Map<WorkTaskDto>(task);

            return Ok(taskDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var task = await workTaskRepository.DeleteAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            var taskDto = Mapper.Map<WorkTaskDto>(task);

            return Ok(taskDto);
        }
    }
}
