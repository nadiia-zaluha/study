using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.BusinessLogic.Abstractions;
using TestProject.Dal;
using TestProject.Dal.Entitites;

namespace TestProject.BusinessLogic.Services
{
    class ProjectDeveloperService : IProjectDeveloperService
    {
        public async Task<bool> InviteDeveloperToProject(int developerId, int projectId)
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                var entity = new ProjectDeveloper
                {
                    DeveloperId = developerId,
                    ProjectId = projectId
                };

                context.ProjectDeveloper.Add(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> DeleteDeveloperFromProject(int developerId, int projectId)
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                var entity = await context.ProjectDeveloper.SingleOrDefaultAsync(item => item.DeveloperId == developerId && item.ProjectId == projectId);
                if (entity == null) return false;

                context.ProjectDeveloper.Remove(entity);

                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<int>> GetAllDeveloperIdsByProject(int projectId)
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {              
                List<int> ids = await context.ProjectDeveloper.Where(item => item.ProjectId == projectId).Select(item => item.DeveloperId).ToListAsync();
                return ids;
            }
        }

        public async Task<List<int>> GetAllProjectIdsByDeveloper(int developerId)
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                List<int> ids = await context.ProjectDeveloper.Where(item => item.DeveloperId == developerId).Select(item => item.ProjectId).ToListAsync();
                return ids;
            }
        }
    }
}
