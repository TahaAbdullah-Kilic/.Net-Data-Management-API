using AutoMapper;
using TaskManagement.API.Models.Domain;
using TaskManagement.API.Models.Dto;

namespace TaskManagement.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
       public AutoMapperProfiles() 
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<AddProjectRequestDto, Project>().ReverseMap();
            CreateMap<UpdateProjectRequestDto, Project>().ReverseMap();
            
            CreateMap<WorkTask, WorkTaskDto>().ReverseMap();
            CreateMap<AddWorkTaskRequestDto, WorkTask>().ReverseMap();
            CreateMap<UpdateWorkTaskRequestDto, WorkTask>().ReverseMap();

            CreateMap<Priority, PriorityDto>().ReverseMap();
        }
    }
}
