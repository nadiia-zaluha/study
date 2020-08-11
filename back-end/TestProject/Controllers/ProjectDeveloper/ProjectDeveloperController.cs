using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.BusinessLogic.Abstractions;
using TestProject.Controllers.ProjectDeveloper.Contract;

namespace TestProject.Controllers.ProjectDeveloper
{
    [Route("api/project-developer")]
    [ApiController]
    public class ProjectDeveloperController : ControllerBase
    {
        private readonly IProjectDeveloperService projectDeveloperService;

        public ProjectDeveloperController(IProjectDeveloperService projectDeveloperService)
        {
            this.projectDeveloperService = projectDeveloperService;
        }

        [HttpPost]
        [Route("assign-developer")]
        public async Task<ActionResult<bool>> InviteDeveloperToProject(DeveloperProjectRequest developer)
        {
            await projectDeveloperService.InviteDeveloperToProject(developer.DeveloperId, developer.ProjectId);
            return true;
        }

        [HttpPost]
        [Route("delete-developer")]
        public async Task<ActionResult<bool>> DeleteDeveloperFromProject(DeveloperProjectRequest developer)
        {
            await projectDeveloperService.DeleteDeveloperFromProject(developer.DeveloperId, developer.ProjectId);
            return true;
        }

        [Route("get-projects-by-developer")]
        [HttpGet]
        public async Task<ActionResult<List<int>>> GetAllProjectIdsByDeveloper(int developerId)
        {
            var ids = await projectDeveloperService.GetAllProjectIdsByDeveloper(developerId);
            return Ok(ids);
        }

        [Route("get-developers-by-project")]
        [HttpGet]
        public async Task<ActionResult<List<int>>> GetAllDeveloperIdsByProject(int projectId)
        {
            var ids = await projectDeveloperService.GetAllDeveloperIdsByProject(projectId);
            return Ok(ids);
        }
    }
}