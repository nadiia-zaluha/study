using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Dal.Entitites
{
   public  class Developer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime WorkedFrom { get; set; }

        public IList<ProjectDeveloper> ProjectDevelopers { get; set; }
    }
}
