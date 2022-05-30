using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBorrowerRepository, BorrowerRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
