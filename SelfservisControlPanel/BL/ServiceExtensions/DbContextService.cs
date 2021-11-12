using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.ServiceExtensions
{
    static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>();

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer("Server=.\\SQLSERVER; Database=SelfServisLogs; user id=fikretcaglar;password=Temp1234; MultipleActiveResultSets=true;"));
            return services;
        }
    }
}
