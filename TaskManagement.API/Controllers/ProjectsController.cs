using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Models.Domain;
using TaskManagement.API.Models.Dto;
using TaskManagement.API.Repositories;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        readonly IProjectRepository projectRepository;
        readonly IMapper mapper;

        public ProjectsController(IProjectRepository projectRepository, IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterQuery,[FromQuery] bool isAscending = true, [FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 100)
        {
            var projects = await projectRepository.GetAllAsync(filterQuery, isAscending, pageNumber, pageSize);

            if (projects == null || !projects.Any())
            {
                return NotFound();
            }

            var projectsDto = mapper.Map<List<ProjectDto>>(projects);

            return Ok(projectsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
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
        public async Task<IActionResult> Create([FromBody] AddProjectRequestDto addProjectRequestDto)
        {

                var project = mapper.Map<Project>(addProjectRequestDto);

                project = await projectRepository.CreateAsync(project);

                var projectDto = mapper.Map<ProjectDto>(project);

                return CreatedAtAction(nameof(GetById), new { id = projectDto.Id }, projectDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
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
