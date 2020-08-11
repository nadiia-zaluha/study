using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Controllers.ProjectDeveloper.Contract
{
    public class DeveloperProjectRequest
    {
        public int ProjectId { get; set; }

        public int DeveloperId { get; set; }
    }
}
