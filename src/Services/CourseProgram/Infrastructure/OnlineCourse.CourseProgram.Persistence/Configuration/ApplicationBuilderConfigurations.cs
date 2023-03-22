using Microsoft.AspNetCore.Builder;
using OnlineCourse.CourseProgram.Persistence.Repositories.EfCore.Context;
using OnlineCourse.CourseProgram.Persistence.Repositories.EfCore.Migrator;
using OnlineCourse.Persistence.Repository.EfCore.Configuration;
using System.Threading.Tasks;

namespace OnlineCourse.CourseProgram.Persistence.Configuration
{
    public static class ApplicationBuilderConfigurations
    {
        public static async Task RunMigratorAsync(this IApplicationBuilder applicationBuilder)
        {
            await applicationBuilder.MigrateDbContextAsync<CourseProgramDbMigrator, CourseProgramDbContext>();
        }
    }
}
