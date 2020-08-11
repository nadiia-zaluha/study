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
    internal class DeveloperService : IDeveloperService

    {
        public async Task<Developer> CreateAsync(string firstName, string lastName, DateTime workedFrom)
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                var entity = new Dal.Entitites.Developer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    WorkedFrom = workedFrom
                };

                context.Developer.Add(entity);
                await context.SaveChangesAsync();

                return ToDomain(entity);

            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                var entity = await context.Developer.SingleOrDefaultAsync(item => item.Id == id);
                if (entity == null) return false;

                context.Developer.Remove(entity);

                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<Developer>> GetAllAsync()
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                var entities = await context.Developer.ToListAsync();
                return entities.Select(ToDomain).ToList();
            }
        }

        public async Task<Developer> UpdatePropertiesAsync(int id, string firstName, string lastName, DateTime workedFrom)
        {
            using (CompanyDbContext context = CompanyDbContext.Create())
            {
                var entity = await context.Developer.SingleOrDefaultAsync(item => item.Id == id);
                if (entity == null) throw new InvalidOperationException($"Developer with id='{id}' not found.");

                entity.FirstName = firstName;
                entity.LastName = lastName;
                entity.WorkedFrom = workedFrom;

                await context.SaveChangesAsync();

                return ToDomain(entity);
            }
        }

        public Developer ToDomain(Dal.Entitites.Developer entity)
        {
            return new Developer(entity.Id, entity.FirstName, entity.LastName, entity.WorkedFrom);
        }
    }
}
