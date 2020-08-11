using Microsoft.Extensions.DependencyInjection;
using TestProject.BusinessLogic.Abstractions;
using TestProject.BusinessLogic.Services;

namespace TestProject.BusinessLogic
{
    public static class BusinessLogicDependencyInjectionExtension
    {
        public static void UseBusinessLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IProjectService), typeof(ProjectService));
            serviceCollection.AddTransient(typeof(IDeveloperService), typeof(DeveloperService));
            serviceCollection.AddTransient(typeof(IProjectDeveloperService), typeof(ProjectDeveloperService));
        }
    }
}
