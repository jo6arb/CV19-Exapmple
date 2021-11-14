using Microsoft.Extensions.DependencyInjection;

namespace CV19.ViewModels
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainvViewModel>();
            services.AddSingleton<CountryStatisticViewModel>();
            services.AddSingleton<WebServerViewModel>();
            return services;
        }
    }
}
