using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineCourse.Application.Common;
using OnlineCourse.CourseProgram.Application.Repositories.Course;
using OnlineCourse.CourseProgram.Persistence.Repositories;
using OnlineCourse.CourseProgram.Persistence.Repositories.EfCore.Context;
using OnlineCourse.CourseProgram.Persistence.Repositories.EfCore.Migrator;
using OnlineCourse.Persistence.Repository.EfCore.Configuration;
using OnlineCourse.Persistence.Repository.EfCore.Migrator;
using OnlineCourse.Persistence.Repository.Settings;

namespace OnlineCourse.CourseProgram.Persistence.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddPersistenceConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database 

            var databaseSetting = new DatabaseSettings();
            configuration.GetSection("DatabaseSettings").Bind(databaseSetting);

            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

            services.AddSingleton<IDataBaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

            services.AddPersistenceEfCoreBaseConfigurations<CourseProgramDbContext>(option =>
            {
                option.ConnectionString = databaseSetting.ConnectionString;
                option.DatabaseType = DatabaseType.PostgreSQL;
            });

            services.AddScoped<ICourseProgramRepository, CourseProgramEfCoreRepository>();
            services.AddScoped<ICourseProgramReadOnlyRepository, CourseProgramEfCoreRepository>();
            services.AddScoped<ICourseProgramCommandRepository, CourseProgramEfCoreRepository>();

            services.AddScoped<ICourseRepository, CourseEfCoreRepository>();
            services.AddScoped<ICourseReadOnlyRepository, CourseEfCoreRepository>();
            services.AddScoped<ICourseCommandRepository, CourseEfCoreRepository>();

            services.AddTransient<IEfCoreMigrator, CourseProgramDbMigrator>();

            #endregion

        }
    }
}
