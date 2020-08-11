using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Dal.Entitites
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartAt { get; set; }

        public IList<ProjectDeveloper> ProjectDevelopers { get; set; }
    }
}
