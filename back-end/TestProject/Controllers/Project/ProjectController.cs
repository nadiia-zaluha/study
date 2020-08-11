using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.BusinessLogic.Abstractions;
using TestProject.Controllers.Project.Contract;
using ProjectDto = TestProject.Controllers.Project.Contract.ProjectDto;

namespace TestProject.Controllers.Project
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> Create(CreateProjectRequest createProject)
        {
            var createdProject = await this.projectService.CreateAsync(createProject.Name, createProject.Description, createProject.StartAt);

            var dto = new ProjectDto
            {
                Id = createdProject.Id,
                Name = createdProject.Name,
                Description = createdProject.Description,
                StartAt = createdProject.StartAt
            };

            return Ok(dto);
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<ActionResult<IList<ProjectDto>>> GetAll()
        {
            var projects = await this.projectService.GetAllAsync();
            var projectsDto = projects.Select(
                item => new ProjectDto
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Name = item.Name,
                        StartAt = item.StartAt
                    }
            ).ToList();

            return Ok(projectsDto);
        }

        [Route("delete")]
        [HttpPost]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool isDeleted = await this.projectService.DeleteAsync(id);
            return Ok(isDeleted);
        }

        [Route("update")]
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> Update(ProjectDto projectInfo)
        {
            var createdProject = await this.projectService.UpdatePropertiesAsync(
                projectInfo.Id,
                projectInfo.Name,
                projectInfo.Description,
                projectInfo.StartAt
            );

            var dto = new ProjectDto
            {
                Id = createdProject.Id,
                Name = createdProject.Name,
                Description = createdProject.Description,
                StartAt = createdProject.StartAt
            };

            return Ok(dto);
        }
    }
}