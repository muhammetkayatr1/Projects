using BL.Repository;
using BL.Repository.ConcreateRepositories;
using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.ServiceExtensions
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Log>>(x => new LogRepository());
            services.AddTransient<IRepository<User>>(x => new UserRepository());
            return services;
        }
    }
}
