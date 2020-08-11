using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.BusinessLogic.ObjectModel
{
    public sealed class Developer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime WorkedFrom { get; set; }

        public Developer(int id, string firstName, string lastName, DateTime workedFrom)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WorkedFrom = workedFrom;
        }
    }
}
