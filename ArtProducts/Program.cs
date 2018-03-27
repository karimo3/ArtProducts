using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ArtProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run(); 
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args) //sets up a default configuration file that we can use (aspsettings.json)
                //.ConfigureAppConfiguration(SetupConfiguration) //manually set up configuration file --> defined below //will use Kestrel web server 
                .UseStartup<Startup>()                              //Iconfiguration service made available - JSON file (appsettings.json)
                .Build();

        //private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        //{
        //    //remove the default configuration options
        //    builder.Sources.Clear();

        //    builder.AddJsonFile("config.json", false, true)
        //           .AddEnvironmentVariables();

        //}
    }
}
