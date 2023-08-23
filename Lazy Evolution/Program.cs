using Microsoft.Extensions.Hosting;
using LazyLib;
using Microsoft.Extensions.DependencyInjection;

namespace Lazy_Evolution;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var builder = Host.CreateDefaultBuilder()
            .ConfigureServices(AddService);
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
    public static void AddService(HostBuilderContext builder, IServiceCollection services)
    {
        services.AddLibServices();
    }
}