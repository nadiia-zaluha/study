using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.BusinessLogic.Abstractions;
using TestProject.Controllers.Developer.Contract;
using DeveloperDto = TestProject.Controllers.Developer.Contract.DeveloperDto;

namespace TestProject.Controllers.Developer
{
    [Route("api/developer")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            this.developerService = developerService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<DeveloperDto>> Create(CreateDeveloperRequest createDeveloper)
        {
            var createdDeveloper = await this.developerService.CreateAsync(createDeveloper.FirstName, createDeveloper.LastName, createDeveloper.WorkedFrom);

            var dto = new DeveloperDto
            {
                Id = createdDeveloper.Id,
                FirstName = createdDeveloper.FirstName,
                LastName = createdDeveloper.LastName,
                WorkedFrom = createdDeveloper.WorkedFrom
            };
            
            return Ok(dto);
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<ActionResult<IList<DeveloperDto>>> GetAll()
        {
            var developers = await this.developerService.GetAllAsync();
            var developersDto = developers.Select(
                item => new DeveloperDto
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    WorkedFrom = item.WorkedFrom
                }            
            ).ToList();

            return Ok(developersDto);
        }

        [Route("delete")]
        [HttpPost]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool isDeleted = await this.developerService.DeleteAsync(id);
            return Ok(isDeleted);
        }

        [Route("update")]
        [HttpPost]
        public async Task<ActionResult<DeveloperDto>> Update(DeveloperDto developerInfo)
        {
            var createdDeveloper = await this.developerService.UpdatePropertiesAsync(
                developerInfo.Id,
                developerInfo.FirstName,
                developerInfo.LastName,
                developerInfo.WorkedFrom
            );

            var dto = new DeveloperDto
            {
                Id = createdDeveloper.Id,
                FirstName = createdDeveloper.FirstName,
                LastName = createdDeveloper.LastName,
                WorkedFrom = createdDeveloper.WorkedFrom
            };

            return Ok(dto);
        }
    }
}