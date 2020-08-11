using System;

namespace TestProject.BusinessLogic.ObjectModel
{
    public sealed class Project
    {
        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public DateTime StartAt { get; }

        public Project(int id, string name, string description, DateTime startAt)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.StartAt = startAt;
        }
    }
}
