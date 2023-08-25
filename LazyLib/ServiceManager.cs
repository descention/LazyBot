using LazyLib.Interfaces;
using LazyLib.Pointers;
using LazyLib.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Unity;

namespace LazyLib
{
    public static class ServiceManager
    {
        static IHost toast;
        public static IServiceProvider Provider => toast.Services;

        public static IServiceCollection AddLibServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IObjectManager, Wow.ObjectManager>()
                .AddHostedService<PulseWorker>();
        }

        public static IHost LibHostBuilder(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services
                .AddLibServices();

            toast = builder.Build();
            return toast;
        }

        private static IPqrOffsets? pqrOffsets = null;
        public static IPqrOffsets? TestOffsets
        {
            get
            {
                if(pqrOffsets == null)
                {
                    pqrOffsets = PqrOffsetImporter.ImportOffsetsFromEmbeddedResource("LazyLib.Resources.PQR_18414.xml");
                }
                return pqrOffsets;
            }
        } 
    }
}