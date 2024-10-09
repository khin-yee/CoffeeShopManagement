using CoffeeShopManagementSystem.Domain.IRepo;
using CoffeeShopManagementSystem.Domain.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepo(this IServiceCollection services)
        {
            services.AddTransient<IRepo.IRepo, Repository>();
            return services;
        }
    }
}
