using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.BusinessLogic.ObjectModel;

namespace TestProject.BusinessLogic.Abstractions
{
    public interface IProjectService
    {
        Task<IList<Project>> GetAllAsync();

        Task<Project> CreateAsync(string name, string description, DateTime startAt);

        Task<Project> UpdatePropertiesAsync(int id, string name, string description, DateTime startAt);

        Task<bool> DeleteAsync(int id);
    }
}
