using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.BusinessLogic.ObjectModel;

namespace TestProject.BusinessLogic.Abstractions
{
    public interface IDeveloperService
    {
        Task<IList<Developer>> GetAllAsync();

        Task<Developer> CreateAsync(string firstName, string lastName, DateTime workedFrom);

        Task<Developer> UpdatePropertiesAsync(int id, string firstName, string lastName, DateTime workedFrom);

        Task<bool> DeleteAsync(int id);
    }
}
