using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalProfileApplication.IServices;
using PersonalProfileApplication.Services;
using PersonalProfilePersistence;
using PersonalProfilePersistence.Context;
using PersonalProfilePersistence.Skills.Repositories;
using System.Reflection;

namespace PersonalProfileCore
{
    public static class DependencyContainer : object
    {
        static DependencyContainer()
        {
        }

        public static void Configureservices
            (Microsoft.Extensions.Configuration.IConfiguration configuration,
            Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            services.AddTransient
                          <Microsoft.AspNetCore.Http.IHttpContextAccessor,
                          Microsoft.AspNetCore.Http.HttpContextAccessor>();

            services.AddAutoMapper
                          (typeof(PersonalProfilePersistence.Mapper.MappingProfile).Assembly);
            services.AddAutoMapper
                          (typeof(PersonalProfileApplication.Skill.MappingProfile).Assembly);
            services.AddDbContext<EntityContext>(x => x.UseSqlServer(configuration.GetConnectionString("MyContext")));
            services.AddTransient
                          (serviceType: typeof(Dtx.Logging.ILogger<>),
                          implementationType: typeof(Dtx.Logging.NLogAdapter<>));
            services.AddTransient<IQueryUnitOfWork, QueryUnitOfWork>(current =>
            {
                string databaseConnectionString =
                   configuration
                    .GetSection(key: "ConnectionString")
                    .Value;

                string databaseProviderString =
                    configuration
                    .GetSection(key: "DatabaseProvider")
                    .Value;

                Dtx.Persistence.Enums.Provider databaseProvider =
                    (Dtx.Persistence.Enums.Provider)
                    System.Convert.ToInt32(databaseProviderString);

                Dtx.Persistence.Options options =
                    new()
                    {
                        Provider = databaseProvider,
                        ConnectionString = databaseConnectionString,
                    };

                return new QueryUnitOfWork(options: options);
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>(current =>
            {
                string databaseConnectionString =
                   configuration
                    .GetSection(key: "ConnectionString")
                    .Value;

                string databaseProviderString =
                    configuration
                    .GetSection(key: "DatabaseProvider")
                    .Value;

                Dtx.Persistence.Enums.Provider databaseProvider =
                    (Dtx.Persistence.Enums.Provider)
                    System.Convert.ToInt32(databaseProviderString);

                Dtx.Persistence.Options options =
                    new()
                    {
                        Provider = databaseProvider,
                        ConnectionString = databaseConnectionString,
                    };

                return new UnitOfWork(options: options);
            });

            services.AddMediatR
              (typeof(PersonalProfileApplication.Skill.MappingProfile).GetTypeInfo().Assembly);
            services.AddValidatorsFromAssembly
              (assembly: typeof(PersonalProfileApplication.Skill.Commands.SkillCommandValidation).Assembly);
            services.AddTransient
              (typeof(MediatR.IPipelineBehavior<,>), typeof(Dtx.Mediator.ValidationBehavior<,>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IFileManager), typeof(FileManager));
            services.AddScoped(typeof(ISMS), typeof(SMS));
            services.AddScoped(typeof(IUserService), typeof(UserService));
        }
    }
}
