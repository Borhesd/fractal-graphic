using Microsoft.Extensions.DependencyInjection;

namespace HostAPI
{
    public static class ServiceProviderExtensions
    {
        public static void AddFeatures(this IServiceCollection services)
        {
            services.AddTransient<SierpinskiFractal.ITriangle,SierpinskiFractal.Triangle>();
        }

    }
}
