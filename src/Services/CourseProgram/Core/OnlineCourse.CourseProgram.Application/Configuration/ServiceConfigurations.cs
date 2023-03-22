using Microsoft.Extensions.DependencyInjection;
using OnlineCourse.Application.Configuration;
using System.Reflection;

namespace OnlineCourse.CourseProgram.Application.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddApplicationConfigurations(this IServiceCollection services)
        {
            services.AddApplicationBaseConfigurations(Assembly.GetExecutingAssembly());
        }
    }
}
