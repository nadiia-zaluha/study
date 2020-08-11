using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Dal.Entitites
{
    public class ProjectDeveloper
    {
        public int DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
