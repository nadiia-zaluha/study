using Microsoft.EntityFrameworkCore.Design;

namespace TestProject.Dal
{
    //1 . Add-Migration 
    //2. Update-Database
    public class ContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
    {
        public CompanyDbContext CreateDbContext(string[] args)
        {
            return CompanyDbContext.Create();
        }
    }
}
