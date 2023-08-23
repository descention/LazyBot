using LazyLib.Interfaces;
using LazyLib.Pointers;
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
        public static IUnityContainer Container = new UnityContainer();
        
        public static IServiceCollection AddLibServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IObjectManager, Wow.ObjectManager>();
        }

        public static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder builder)
        {
            
            return builder;
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