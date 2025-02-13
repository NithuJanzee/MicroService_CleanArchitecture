using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{
    //Core is the bussneiss logic layer 
    public static class DependencyInjection
    {
        /// <summary>
        /// Extenction methord to add infrastructure service to dependency injection container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
       
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
