using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Controllers.Developer.Contract
{
    public class CreateDeveloperRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime WorkedFrom { get; set; }
    }
}
