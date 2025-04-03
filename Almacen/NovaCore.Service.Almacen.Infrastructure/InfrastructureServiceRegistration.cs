using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NovaCore.Common.Application;
using NovaCore.Service.Almacen.Application.IRepositories;
using NovaCore.Service.Almacen.Infrastructure.Repositories;

namespace NovaCore.Service.Almacen.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static object AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AlmacenDbContext>(opts =>
                opts.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsHistoryTable("__EFMigrationHistory", "dbo")
                    )
                );

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            // Repositories
            services.AddScoped<ITestRepository, TestRepository>();

            return services;
        }
    }
}