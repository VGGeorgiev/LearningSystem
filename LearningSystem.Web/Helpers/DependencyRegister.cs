namespace LearningSystem.Web
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;
    using LearningSystem.Infrastructure;
    using LearningSystem.Infrastructure.Services;

    public static class DependencyRegister
    {
        private const string InterfacePrefix = "I";
        private static readonly List<Assembly> Assemblies = new List<Assembly>
        {
            typeof(DataContext).Assembly, // LearningSystem.Infrastructure
            typeof(UserService).Assembly // LearningSystem.Services
        };

        public static void AddProjectDependencies(this IServiceCollection services)
        {
            foreach (var assembly in Assemblies)
            {
                var types = assembly.GetTypes()
                    .Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType)
                    .Where(x => x.GetInterfaces().Any(i => i.Name == $"{InterfacePrefix}{x.Name}"));
                foreach (var type in types)
                {
                    var typeInterface = type.GetInterface($"{InterfacePrefix}{type.Name}");
                    services.AddTransient(typeInterface, type);
                }
            }
        }
    }
}
