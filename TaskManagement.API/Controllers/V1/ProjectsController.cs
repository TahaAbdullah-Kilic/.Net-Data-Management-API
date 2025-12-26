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
    public class ProjectsController : ControllerBase
    {
        readonly IProjectRepository projectRepository;
        readonly IMapper mapper;
        readonly ILogger<ProjectsController> logger;

        public ProjectsController(IProjectRepository projectRepository, IMapper mapper, ILogger<ProjectsController> logger)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterQuery,[FromQuery] bool isAscending = true, [FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 100)
        {            
            var projects = await projectRepository.GetAllAsync(filterQuery, isAscending, pageNumber, pageSize);

            var projectsDto = mapper.Map<List<ProjectDto>>(projects);

            return Ok(projectsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var project = await projectRepository.GetByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            var projectDto = mapper.Map<ProjectDto>(project);

            return Ok(projectDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddProjectRequestDto addProjectRequestDto)
        {

                var project = mapper.Map<Project>(addProjectRequestDto);

                project = await projectRepository.CreateAsync(project);

                var projectDto = mapper.Map<ProjectDto>(project);

                return CreatedAtAction(nameof(GetById), new { id = projectDto.Id }, projectDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProjectRequestDto updateProjectRequestDto)
        {
                var project = mapper.Map<Project>(updateProjectRequestDto);

                project = await projectRepository.UpdateAsync(id, project);

                if (project == null)
                {
                    return NotFound();
                }

                var projectDto = mapper.Map<ProjectDto>(project);

                return Ok(projectDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var project = await projectRepository.DeleteAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            var projectDto = mapper.Map<ProjectDto>(project);

            return Ok(projectDto);
        }
    }
}
