using DataAccess.HrModuleEvents.Interfaces;
using DataAccess.HrModuleEvents.Reposities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DependencyInjections
{
    public static class ReposDependencyInjections
    {
        public static void LoadReposDependencyInjections(this IServiceCollection Service)
        {
            Service.AddScoped<IUserEventsRepository,UserEventsRepository>();
            Service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
