using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Controllers.Project.Contract
{
    public class CreateProjectRequest
    {
        public string Name { get; set; }        

        public string Description { get; set; }

        public DateTime StartAt { get; set; }
    }
}
