using Microsoft.Extensions.DependencyInjection;

namespace HostAPI
{
    public static class ServiceProviderExtensions
    {
        public static void AddFeatures(this IServiceCollection services)
        {
            services.AddScoped<Services.TriangleFractalService>();
        }

    }
}
