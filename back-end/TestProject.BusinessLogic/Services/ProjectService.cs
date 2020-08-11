using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.BusinessLogic.Abstractions;
using TestProject.BusinessLogic.ObjectModel;
using TestProject.Dal;

namespace TestProject.BusinessLogic.Services
{
    internal class ProjectService : IProjectService
    {
        public async Task<Project> CreateAsync(string name, string description, DateTime startAt)
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                var entity = new Dal.Entitites.Project
                {
                    Description = description,
                    Name = name,
                    StartAt = startAt
                };

                context.Project.Add(entity);

                await context.SaveChangesAsync();

                return ToDomain(entity);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                var entity = await context.Project.SingleOrDefaultAsync(item => item.Id == id);
                if (entity == null) return false;

                context.Project.Remove(entity);

                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<IList<Project>> GetAllAsync()
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                var entities = await context.Project.ToListAsync();
                return entities.Select(ToDomain).ToList();
            }
        }

        public async Task<Project> UpdatePropertiesAsync(int id, string name, string description, DateTime startAt)
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                var entity = await context.Project.SingleOrDefaultAsync(item => item.Id == id);
                if (entity == null) throw new InvalidOperationException($"Project with id='{id}' not found.");

                entity.Name = name;
                entity.Description = description;
                entity.StartAt = startAt;

                await context.SaveChangesAsync();

                return ToDomain(entity);
            }
        }

        public Project ToDomain(Dal.Entitites.Project entity)
        {
            return new Project(entity.Id, entity.Name, entity.Description, entity.StartAt);
        }
    }
}
