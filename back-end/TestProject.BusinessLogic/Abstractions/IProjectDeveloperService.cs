using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BusinessLogic.Abstractions
{
    public interface IProjectDeveloperService
    {
        Task<bool> InviteDeveloperToProject(int developerId, int projectId);

        Task<bool> DeleteDeveloperFromProject(int developerId, int projectId);

        Task<List<int>> GetAllProjectIdsByDeveloper(int developerId);

        Task<List<int>> GetAllDeveloperIdsByProject(int projectId);

    }
}
