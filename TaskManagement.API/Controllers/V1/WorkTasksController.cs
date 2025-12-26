using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Models.Domain;
using TaskManagement.API.Models.Dto;
using TaskManagement.API.Repositories;

namespace TaskManagement.API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class WorkTasksController : ControllerBase
    {
        readonly IWorkTaskRepository workTaskRepository;
        readonly IMapper Mapper;

        public WorkTasksController(IWorkTaskRepository workTaskRepository, IMapper mapper)
        {
            this.workTaskRepository = workTaskRepository;
            Mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool isAscending = true, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
        {
            var tasks = await workTaskRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);

            var tasksDto = Mapper.Map<List<WorkTaskDto>>(tasks);

            return Ok(tasksDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "User")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddWorkTaskRequestDto addWorkTaskRequestDto)
        {
                var task = Mapper.Map<WorkTask>(addWorkTaskRequestDto);

                task = await workTaskRepository.CreateAsync(task);

                var taskDto = Mapper.Map<WorkTaskDto>(task);

                return CreatedAtAction(nameof(GetById), new { id = taskDto.Id }, taskDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
